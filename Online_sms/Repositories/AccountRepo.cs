using Online_sms.Interfaces;
using Online_sms.Models;
using Online_sms.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.RegularExpressions;

namespace Online_sms.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly DatabaseContext _context;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;
        private readonly IAuthRepo _authRepo;
        private readonly IWebHostEnvironment _env;


        public AccountRepo(DatabaseContext context, IMailService mailService, IConfiguration configuration, IAuthRepo authRepo, IWebHostEnvironment env)
        {
            _context = context;
            _mailService = mailService;
            _configuration = configuration;
            _authRepo = authRepo;
            _env = env;
        }

        public async Task<CustomResult> CheckEmailUnique(string email)
        {
            var account = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (account != null)
            {
                return new CustomResult(400, "Email exist!", null);
            }

            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            if (!Regex.IsMatch(email, regex, RegexOptions.IgnoreCase))
            {
                return new CustomResult(400, "Email is wrong!", null);
            }
            //neu dung het
            return new CustomResult(200, "Email accepted!", null);
        }

        public async Task<CustomResult> CheckPhoneUnique(string phone)
        {
            var account = await _context.Users.FirstOrDefaultAsync(u => u.Phone_Number == phone);

            if (account != null)
            {
                return new CustomResult(400, "This Phone number had been registered already!", null);
            }

            if (phone.Length != 10 || !phone.All(char.IsDigit))
            {
                return new CustomResult(400, "Phone number should be 10 digits long and contain only numeric characters!", null);
            }

            return new CustomResult(200, "Phone number accepted!", null);
        }

        public async Task<CustomResult> CheckUsername(string username)
        {
            var account = await _context.Users.FirstOrDefaultAsync(u => u.User_name == username);

            if (account != null)
            {
                return new CustomResult(400, "Username exitst!", null);
            }
            // start with a letter, allow letter or number, length between 8 to 12.
            string regex = @"^[a-zA-Z][a-zA-Z0-9]{7,11}$";
            if (!Regex.IsMatch(username, regex, RegexOptions.IgnoreCase))
            {
                return new CustomResult(400, "Username need to start with a letter and atleast 8 character with character or number, maximum 12 character!", null);
            }

            return new CustomResult(200, "Username accepted!", null);
        }

        public async Task<CustomResult> CheckPassword(string password)
        {
            // Password phai co mot so tu 0-9, mot chu khong hoa, mot chu co hoa
            // it nhat mot ky tu dac biet, phai dai 8-10 tu
            string regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$";

            if (!Regex.IsMatch(password, regex))
            {
                return new CustomResult(400, "Password must contain one digit, one lowercase letter, one uppercase letter, one special character (@$!%*?&), and it must be 8-10 characters long!", null);
            }

            return new CustomResult(200, "Password accepted!", null);
        }

        public async Task<CustomResult> Register(Register register)
        {
            var emailValidationResult = await CheckEmailUnique(register.Email);
            if (emailValidationResult.Message != "Email accepted!")
            {
                return emailValidationResult;
            }

            var phoneValidationResult = await CheckPhoneUnique(register.PhoneNumber);
            if (phoneValidationResult.Message != "Phone number accepted!")
            {
                return phoneValidationResult;
            }

            var usernameValidationResult = await CheckUsername(register.Username);
            if (usernameValidationResult.Message != "Username accepted!")
            {
                return usernameValidationResult;
            }
            var passwordValidationResult = await CheckPassword(register.Password);
            if (passwordValidationResult.Message != "Password accepted!")
            {
                return passwordValidationResult;
            }


            var user = new User()
            {
                User_name = register.Username,
                Fullname = register.Fullname,
                Email = register.Email,
                Phone_Number = register.PhoneNumber,
                gender = User.Gender.other,
                Password = BCrypt.Net.BCrypt.HashPassword(register.Password),
                DOB = DateTime.Parse(register.DOBString),

                IsEmailConfirmed = false,
                ConfirmationCode = GenerateConfirmationCode(),
                Subcription_id = 1,
                SubscriptionEndDate = DateTime.UtcNow.AddDays(1)
            };

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                //gửi mail tới để còmirm 
                var token = _authRepo.CreateToken(user, DateTime.Now.AddMonths(1));
                var url = $"{_configuration["ClientInfo:Url"]}/Login?token={token}";

                await _mailService.SendMailAsync(new MailRequest()
                {
                    ToEmail = user.Email,
                    Body = GenerateEmailBody(url, user.ConfirmationCode),
                    Subject = "Email Confirmation for Chat",
                    Attachments = null
                });

                return new CustomResult(200, "created success", user);
            }
            catch (Exception ex)
            {
                return new CustomResult(400, ex.Message, null);
            }
        }
        public string GenerateConfirmationCode()
        {
            var random = new Random();
            var code = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                code.Append(random.Next(0, 10));
            }
            return code.ToString();
        }
        public async Task<CustomResult> VerifyEmailConfirmationCode(User user, string enteredCode)
        {
            if (user.ConfirmationCode == enteredCode)
            {
                user.IsEmailConfirmed = true;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return new CustomResult(200, "Email confirmed successfully", user);
            }
            else
            {
                return new CustomResult(400, "Invalid confirmation code", null);
            }
        }



        public async Task<CustomResult> UploadImage(string email, IFormFile uploadImage)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);

            var fileName = GenerateUniqueName(uploadImage.FileName);
            var uploadPath = Path.Combine(_env.WebRootPath, "images");
            var filePath = Path.Combine(uploadPath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await uploadImage.CopyToAsync(fileStream);
            }

            user.Image = fileName;

            await _context.SaveChangesAsync();

            return new CustomResult(200, "Success", user);

        }

        private string GenerateEmailBody(string url, string code)
        {
            var emailBody = $"<h1 style=\"color: red\">Email Confirm</h1>\r\n    " +
                $"<p style=\"font-size: 18px\">Please click on this <a href='{url}'>Link</a> to confirm your registration</p>\r\n  </br>  <p>Code:{code}</p>" +
                $"<h5 style=\"font-size: 17px\">Thank you</h5>";

            return emailBody;
        }

        private string GenerateUniqueName(string name)
        {
            var fileName = Path.GetFileName(name);

            return Path.GetFileNameWithoutExtension(fileName) + DateTime.Now.Ticks + Path.GetExtension(fileName);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public Task<CustomResult> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResult> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<CustomResult> SearchUser(string search)
        {
            var list = await _context.Users.Where(u => u.Phone_Number.Contains(search)).Take(10).ToListAsync();

            return new CustomResult(200, "done", list);
        }
    }
}