﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Online_sms.Migrations
{
    /// <inheritdoc />
    public partial class i : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Room_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Room_Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChatLimit = table.Column<int>(type: "int", nullable: false),
                    enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Create_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subcription_id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                    table.ForeignKey(
                        name: "FK_Users_Subscriptions_Subcription_id",
                        column: x => x.Subcription_id,
                        principalTable: "Subscriptions",
                        principalColumn: "SubscriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "SubscriptionId");
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Friend_Id = table.Column<int>(type: "int", nullable: false),
                    Accept = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FriendUserUser_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_Users_FriendUserUser_id",
                        column: x => x.FriendUserUser_id,
                        principalTable: "Users",
                        principalColumn: "User_id");
                    table.ForeignKey(
                        name: "FK_Friends_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Message_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Message_Id);
                    table.ForeignKey(
                        name: "FK_Messages_Rooms_Room_Id",
                        column: x => x.Room_Id,
                        principalTable: "Rooms",
                        principalColumn: "Room_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Payment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Card_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cvv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Payment_Id);
                    table.ForeignKey(
                        name: "FK_Payment_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "ChatLimit", "Create_at", "Name", "Price", "enddate" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2024, 7, 4, 17, 7, 23, 971, DateTimeKind.Local).AddTicks(6409), "Chat Free", 0m, new DateTime(2024, 7, 5, 17, 7, 23, 971, DateTimeKind.Local).AddTicks(6426) },
                    { 2, -1, new DateTime(2024, 7, 4, 17, 7, 23, 971, DateTimeKind.Local).AddTicks(6435), "Unlimited Chat (1 day)", 1m, new DateTime(2024, 7, 5, 17, 7, 23, 971, DateTimeKind.Local).AddTicks(6435) },
                    { 3, -1, new DateTime(2024, 7, 4, 17, 7, 23, 971, DateTimeKind.Local).AddTicks(6437), "Unlimited Chat (1 month)", 5m, new DateTime(2024, 8, 4, 17, 7, 23, 971, DateTimeKind.Local).AddTicks(6437) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "User_id", "Balance", "ConfirmationCode", "CreatedAt", "Email", "IsEmailConfirmed", "Password", "Phone_Number", "Subcription_id", "SubscriptionId", "UpdatedAt", "User_name" },
                values: new object[,]
                {
                    { 1, 0m, null, new DateTime(2024, 7, 4, 10, 7, 23, 969, DateTimeKind.Utc).AddTicks(3937), "SigridIV@gmail.com", false, "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "568-034-7878", 1, null, new DateTime(2024, 7, 4, 10, 7, 23, 969, DateTimeKind.Utc).AddTicks(3939), "Jamison Denesik" },
                    { 2, 0m, null, new DateTime(2024, 7, 4, 10, 7, 23, 969, DateTimeKind.Utc).AddTicks(6056), "CarmelaIV@gmail.com", false, "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "1-852-264-3156 x572", 1, null, new DateTime(2024, 7, 4, 10, 7, 23, 969, DateTimeKind.Utc).AddTicks(6056), "Mr. Damien Kip Rath" },
                    { 3, 0m, null, new DateTime(2024, 7, 4, 10, 7, 23, 970, DateTimeKind.Utc).AddTicks(297), "DakotaI@gmail.com", false, "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "706.255.7211 x340", 1, null, new DateTime(2024, 7, 4, 10, 7, 23, 970, DateTimeKind.Utc).AddTicks(298), "Prof. Chelsey Georgianna Mitchell" },
                    { 4, 0m, null, new DateTime(2024, 7, 4, 10, 7, 23, 970, DateTimeKind.Utc).AddTicks(2549), "ChadrickMD@gmail.com", false, "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "847.906.7110 x0896", 1, null, new DateTime(2024, 7, 4, 10, 7, 23, 970, DateTimeKind.Utc).AddTicks(2549), "Bradley Bosco" },
                    { 5, 0m, null, new DateTime(2024, 7, 4, 10, 7, 23, 970, DateTimeKind.Utc).AddTicks(4117), "HaleighDDS@gmail.com", false, "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "1-819-295-7835 x922", 1, null, new DateTime(2024, 7, 4, 10, 7, 23, 970, DateTimeKind.Utc).AddTicks(4117), "Mr. Laurine Tianna Bailey V" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendUserUser_id",
                table: "Friends",
                column: "FriendUserUser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_User_Id",
                table: "Friends",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_Room_Id",
                table: "Messages",
                column: "Room_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_User_Id",
                table: "Messages",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_User_Id",
                table: "Payment",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Subcription_id",
                table: "Users",
                column: "Subcription_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubscriptionId",
                table: "Users",
                column: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
