﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Online_sms.Models;

#nullable disable

namespace Online_sms.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240618033207_inti")]
    partial class inti
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Online_sms.Models.ChatLimit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ChatLimits");
                });

            modelBuilder.Entity("Online_sms.Models.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FriendUserUser_id")
                        .HasColumnType("int");

                    b.Property<int>("Friend_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FriendUserUser_id");

                    b.HasIndex("User_Id");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("Online_sms.Models.Room", b =>
                {
                    b.Property<int>("Room_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Room_Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Room_Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Online_sms.Models.RoomMessage", b =>
                {
                    b.Property<int>("Message_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Message_Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Room_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Message_Id");

                    b.HasIndex("Room_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Online_sms.Models.User", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_id"));

                    b.Property<string>("ConfirmationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            User_id = 1,
                            CreatedAt = new DateTime(2024, 6, 18, 3, 32, 6, 510, DateTimeKind.Utc).AddTicks(6310),
                            Email = "BrandtDVM@gmail.com",
                            IsEmailConfirmed = false,
                            Password = "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa",
                            Phone_Number = "1-573-113-3670 x550",
                            User_name = "Clementine Stiedemann"
                        },
                        new
                        {
                            User_id = 2,
                            CreatedAt = new DateTime(2024, 6, 18, 3, 32, 6, 511, DateTimeKind.Utc).AddTicks(377),
                            Email = "JulianneDVM@gmail.com",
                            IsEmailConfirmed = false,
                            Password = "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa",
                            Phone_Number = "296-244-4379",
                            User_name = "Cora Von"
                        },
                        new
                        {
                            User_id = 3,
                            CreatedAt = new DateTime(2024, 6, 18, 3, 32, 6, 511, DateTimeKind.Utc).AddTicks(2492),
                            Email = "KianaDVM@gmail.com",
                            IsEmailConfirmed = false,
                            Password = "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa",
                            Phone_Number = "691.701.8685",
                            User_name = "Virgil Imelda Mann V"
                        },
                        new
                        {
                            User_id = 4,
                            CreatedAt = new DateTime(2024, 6, 18, 3, 32, 6, 511, DateTimeKind.Utc).AddTicks(5863),
                            Email = "VivianV@gmail.com",
                            IsEmailConfirmed = false,
                            Password = "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa",
                            Phone_Number = "278.148.0361 x0050",
                            User_name = "Casimir Stoltenberg"
                        },
                        new
                        {
                            User_id = 5,
                            CreatedAt = new DateTime(2024, 6, 18, 3, 32, 6, 511, DateTimeKind.Utc).AddTicks(7556),
                            Email = "SandyDVM@gmail.com",
                            IsEmailConfirmed = false,
                            Password = "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa",
                            Phone_Number = "261.741.8024",
                            User_name = "Fred Pacocha"
                        });
                });

            modelBuilder.Entity("Online_sms.Models.ChatLimit", b =>
                {
                    b.HasOne("Online_sms.Models.User", "User")
                        .WithOne("ChatLimit")
                        .HasForeignKey("Online_sms.Models.ChatLimit", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Online_sms.Models.Friend", b =>
                {
                    b.HasOne("Online_sms.Models.User", "FriendUser")
                        .WithMany()
                        .HasForeignKey("FriendUserUser_id");

                    b.HasOne("Online_sms.Models.User", "User")
                        .WithMany("Friends")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FriendUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Online_sms.Models.RoomMessage", b =>
                {
                    b.HasOne("Online_sms.Models.Room", "ChatRoom")
                        .WithMany("Messages")
                        .HasForeignKey("Room_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_sms.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatRoom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Online_sms.Models.Room", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Online_sms.Models.User", b =>
                {
                    b.Navigation("ChatLimit")
                        .IsRequired();

                    b.Navigation("Friends");

                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
