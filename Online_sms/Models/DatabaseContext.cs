using Microsoft.EntityFrameworkCore;
using static Online_sms.Models.User;

namespace Online_sms.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomMessage> Messages { get; set; }

        public DbSet<Friend> Friends { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(options =>
            {
                options.HasKey(u => u.User_id);
                options.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");

                options.HasMany(u => u.Friends)
                    .WithOne(f => f.User)
                    .HasForeignKey(f => f.User_Id)
                    .OnDelete(DeleteBehavior.Cascade);

                options.HasOne(u => u.Subscription)
                    .WithMany()
                    .HasForeignKey(u => u.Subcription_id)
                    .OnDelete(DeleteBehavior.Cascade);

                var listUser = new List<User>();

                string[] listImage = ["4.png",
                                    "5.png",
                                    "6.png",
                                    "7.jpg",
                                    "8.jpg",
                                    "10.png",
                                    "11.jpg"];

                Random random = new Random();

                for (int i = 0; i < 5; i++)
                {
                    var workStatus = (WorkStatus)random.Next(0, 3);
                    var gender = (Gender)random.Next(0, 3);
                    listUser.Add(new User()
                    {
                        User_id = i + 1,
                        User_name = Faker.Name.First(),
                        Fullname = Faker.Name.FullName(),
                        Email = Faker.Name.First() + Faker.Name.Suffix() + "@gmail.com",
                        Password = "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa",
                        Balance = 0,
                        Phone_Number = Faker.Phone.Number(),
                        Subcription_id = 1,
                        Address = Faker.Address.StreetAddress(),
                        gender = gender,
                        MaritalStatus = false,
                        Image = listImage[random.Next(listImage.Length)],

                        DOB = DateTime.Now,
                        Hobbies = string.Join(", ", Faker.Lorem.Words(3)),
                        Likes = string.Join(", ", Faker.Lorem.Words(3)),
                        Dislikes = string.Join(", ", Faker.Lorem.Words(3)),

                        Cuisines = "food",
                        Sports = "soccer",
                        Qualifications = "Bachelor's Degree",
                        School = "Sample High School",
                        Work_Status = workStatus,
                        College = Faker.Company.Name(),
                        Designation = "1",

                        Organisation =  Faker.Company.Name(),
                        SubscriptionEndDate = DateTime.Now.AddDays(1),
                        IsEmailConfirmed = true,
                    });
                }
                options.HasData(listUser);

                modelBuilder.Entity<Room>(options =>
                {
                    options.HasKey(c => c.Room_Id);
                    options.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
                    options.Property(u => u.UpdatedAt).HasDefaultValueSql("GETDATE()");
                });
                modelBuilder.Entity<Friend>().HasKey(f=>f.Id);
                modelBuilder.Entity<RoomMessage>(options =>
                {
                    options.HasKey(c => c.Message_Id);
                    options.HasOne(c => c.User).WithMany(u => u.Messages).HasForeignKey(c => c.User_Id);
                    options.HasOne(c => c.ChatRoom).WithMany(c => c.Messages).HasForeignKey(c => c.Room_Id);

                    options.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
                });
                modelBuilder.Entity<Payment>()
                    .HasOne(p => p.User)
                    .WithMany(u => u.Payments)
                    .HasForeignKey(p => p.User_Id);

                modelBuilder.Entity<Subscription>().HasData(
                    new Subscription { SubscriptionId = 1, Name = "Chat Free", ChatLimit = 5, Create_at = DateTime.Now, enddate = DateTime.Now.AddDays(1), Price = 0 },
                    new Subscription { SubscriptionId = 2, Name = "Unlimited Chat (1 day)", ChatLimit = -1, Create_at = DateTime.Now, enddate = DateTime.Now.AddDays(1), Price = 1 },
                    new Subscription { SubscriptionId = 3, Name = "Unlimited Chat (1 month)", ChatLimit = -1, Create_at = DateTime.Now, enddate = DateTime.Now.AddMonths(1), Price = 5 }
                );  
                modelBuilder.Entity<User>()
                .Property(u => u.Balance)
                .HasColumnType("decimal(18,2)");

                modelBuilder.Entity<Subscription>()
                    .Property(s => s.Price)
                    .HasColumnType("decimal(18,2)");
            });
        }
    } 
}
