using Online_sms.Interfaces;
using Online_sms.Models;
using Online_sms.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

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

        public async Task<bool> CheckEmailUnique(string email)
        {
            var account = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);

            if (account == null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> CheckPhoneUnique(string phone)
        {
            var account = await _context.Users.SingleOrDefaultAsync(u => u.Phone_Number == phone);

            if (account == null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> CheckUsername(string username)
        {
            var account = await _context.Users.SingleOrDefaultAsync(u => u.User_name == username);

            if (account == null)
            {
                return true;
            }

            return false;
        }

        public async Task<CustomResult> Register(Register register)
        {
            var verified = await CheckEmailUnique(register.Email);

            if(!verified)
            {
                return new CustomResult(400, "Email exist!", null);
            }

            verified = await CheckUsername(register.Username);
            if (!verified)
            {
                return new CustomResult(400, "Username exitst!", null);
            }

            verified = await CheckPhoneUnique(register.PhoneNumber);

            if (!verified)
            {
                return new CustomResult(400, "Phone number exist!", null);
            }

            var user = new User()
            {
                User_name = register.Username,
                Email = register.Email,
                Phone_Number = register.PhoneNumber,
                Password = BCrypt.Net.BCrypt.HashPassword(register.Password),
                IsEmailConfirmed = false,
                ConfirmationCode = GenerateConfirmationCode(),
                Subcription_id = 1
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
            }catch (Exception ex)
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

        public async Task<CustomResult> UploadImage(string email, IFormFile uploadImage)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);    

            var fileName = GenerateUniqueName(uploadImage.FileName);
            var uploadPath = Path.Combine(_env.WebRootPath, "images");
            var filePath = Path.Combine(uploadPath, fileName);

            using(var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await uploadImage.CopyToAsync(fileStream);
            }

            //user.Image = fileName;

            await _context.SaveChangesAsync();

            return new CustomResult(200, "Success", user);

        }

        private string GenerateEmailBody(string url,string code)
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

        public async Task<CustomResult> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return new CustomResult(200, "update Success", user);
        }
    }
}
