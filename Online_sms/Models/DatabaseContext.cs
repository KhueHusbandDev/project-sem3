using Microsoft.EntityFrameworkCore;

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

                Random random = new Random();

                for (int i = 0; i < 5; i++)
                {
                    listUser.Add(new User()
                    {
                        User_id = i + 1,
                        User_name = Faker.Name.FullName(),
                        Email = Faker.Name.First() + Faker.Name.Suffix() + "@gmail.com",
                        Password = "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa",
                        Balance = 0,
                        Phone_Number = Faker.Phone.Number(),
                        Subcription_id = 1,
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
