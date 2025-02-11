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
    [Migration("20240705093231_int")]
    partial class @int
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Online_sms.Models.Contact", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.HasKey("id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Online_sms.Models.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Accept")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("Online_sms.Models.Payment", b =>
                {
                    b.Property<int>("Payment_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Payment_Id"));

                    b.Property<string>("Card_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Create_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cvv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Payment_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Payment");
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

            modelBuilder.Entity("Online_sms.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionId"));

                    b.Property<int>("ChatLimit")
                        .HasColumnType("int");

                    b.Property<DateTime>("Create_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("enddate")
                        .HasColumnType("datetime2");

                    b.HasKey("SubscriptionId");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            SubscriptionId = 1,
                            ChatLimit = 5,
                            Create_at = new DateTime(2024, 7, 5, 16, 32, 31, 438, DateTimeKind.Local).AddTicks(2703),
                            Name = "Chat Free",
                            Price = 0m,
                            enddate = new DateTime(2024, 7, 6, 16, 32, 31, 438, DateTimeKind.Local).AddTicks(2717)
                        },
                        new
                        {
                            SubscriptionId = 2,
                            ChatLimit = -1,
                            Create_at = new DateTime(2024, 7, 5, 16, 32, 31, 438, DateTimeKind.Local).AddTicks(2729),
                            Name = "Unlimited Chat (1 day)",
                            Price = 1m,
                            enddate = new DateTime(2024, 7, 6, 16, 32, 31, 438, DateTimeKind.Local).AddTicks(2730)
                        },
                        new
                        {
                            SubscriptionId = 3,
                            ChatLimit = -1,
                            Create_at = new DateTime(2024, 7, 5, 16, 32, 31, 438, DateTimeKind.Local).AddTicks(2731),
                            Name = "Unlimited Chat (1 month)",
                            Price = 5m,
                            enddate = new DateTime(2024, 8, 5, 16, 32, 31, 438, DateTimeKind.Local).AddTicks(2732)
                        });
                });

            modelBuilder.Entity("Online_sms.Models.User", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

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

                    b.Property<int>("Subcription_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubscriptionEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("User_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_id");

                    b.HasIndex("Subcription_id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            User_id = 1,
                            Balance = 0m,
                            CreatedAt = new DateTime(2024, 7, 5, 9, 32, 31, 436, DateTimeKind.Utc).AddTicks(526),
                            Email = "BerniceV@gmail.com",
                            IsEmailConfirmed = false,
                            Password = "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa",
                            Phone_Number = "(777)582-7497 x77035",
                            Subcription_id = 1,
                            SubscriptionEndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2024, 7, 5, 9, 32, 31, 436, DateTimeKind.Utc).AddTicks(528),
                            User_name = "D'angelo Mills"
                        },
                        new
                        {
                            User_id = 2,
                            Balance = 0m,
                            CreatedAt = new DateTime(2024, 7, 5, 9, 32, 31, 436, DateTimeKind.Utc).AddTicks(2826),
                            Email = "PaigeJr.@gmail.com",
                            IsEmailConfirmed = false,
                            Password = "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa",
                            Phone_Number = "668-270-1938",
                            Subcription_id = 1,
                            SubscriptionEndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2024, 7, 5, 9, 32, 31, 436, DateTimeKind.Utc).AddTicks(2827),
                            User_name = "Jackie Baumbach"
                        },
                        new
                        {
                            User_id = 3,
                            Balance = 0m,
                            CreatedAt = new DateTime(2024, 7, 5, 9, 32, 31, 436, DateTimeKind.Utc).AddTicks(4635),
                            Email = "AustinJr.@gmail.com",
                            IsEmailConfirmed = false,
                            Password = "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa",
                            Phone_Number = "417-037-7157 x03369",
                            Subcription_id = 1,
                            SubscriptionEndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2024, 7, 5, 9, 32, 31, 436, DateTimeKind.Utc).AddTicks(4635),
                            User_name = "Daniella Hane"
                        },
                        new
                        {
                            User_id = 4,
                            Balance = 0m,
                            CreatedAt = new DateTime(2024, 7, 5, 9, 32, 31, 436, DateTimeKind.Utc).AddTicks(6611),
                            Email = "FloyJr.@gmail.com",
                            IsEmailConfirmed = false,
                            Password = "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa",
                            Phone_Number = "(193)376-8279 x139",
                            Subcription_id = 1,
                            SubscriptionEndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2024, 7, 5, 9, 32, 31, 436, DateTimeKind.Utc).AddTicks(6611),
                            User_name = "Lenny Bauch"
                        },
                        new
                        {
                            User_id = 5,
                            Balance = 0m,
                            CreatedAt = new DateTime(2024, 7, 5, 9, 32, 31, 436, DateTimeKind.Utc).AddTicks(8462),
                            Email = "TheoDDS@gmail.com",
                            IsEmailConfirmed = false,
                            Password = "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa",
                            Phone_Number = "(508)979-9012 x625",
                            Subcription_id = 1,
                            SubscriptionEndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2024, 7, 5, 9, 32, 31, 436, DateTimeKind.Utc).AddTicks(8463),
                            User_name = "Prof. Seth Tavares Stroman IV"
                        });
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

            modelBuilder.Entity("Online_sms.Models.Payment", b =>
                {
                    b.HasOne("Online_sms.Models.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("Online_sms.Models.User", b =>
                {
                    b.HasOne("Online_sms.Models.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("Subcription_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_sms.Models.Subscription", null)
                        .WithMany("User")
                        .HasForeignKey("SubscriptionId");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("Online_sms.Models.Room", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Online_sms.Models.Subscription", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Online_sms.Models.User", b =>
                {
                    b.Navigation("Friends");

                    b.Navigation("Messages");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
