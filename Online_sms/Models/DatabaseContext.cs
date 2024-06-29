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

        public DbSet<ChatLimit> ChatLimits { get; set; }

        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(options =>
            {
                options.HasKey(u => u.User_id);
                options.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");

                options.HasOne(u => u.ChatLimit)
                    .WithOne(cl => cl.User)
                    .HasForeignKey<ChatLimit>(cl => cl.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                options.HasMany(u => u.Friends)
                    .WithOne(f => f.User)
                    .HasForeignKey(f => f.User_Id)
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
                        Phone_Number = Faker.Phone.Number()
                    });
                }
                options.HasData(listUser);

                modelBuilder.Entity<Room>(options =>
                {
                    options.HasKey(c => c.Room_Id);
                    options.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
                    options.Property(u => u.UpdatedAt).HasDefaultValueSql("GETDATE()");
                });
                modelBuilder.Entity<ChatLimit>(entity =>
                {
                    entity.HasKey(cl => cl.Id) ;
                });
                modelBuilder.Entity<Friend>().HasKey(f=>f.Id);
                modelBuilder.Entity<RoomMessage>(options =>
                {
                    options.HasKey(c => c.Message_Id);
                    options.HasOne(c => c.User).WithMany(u => u.Messages).HasForeignKey(c => c.User_Id);
                    options.HasOne(c => c.ChatRoom).WithMany(c => c.Messages).HasForeignKey(c => c.Room_Id);

                    options.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
                });
            });
        }
    } 
}
