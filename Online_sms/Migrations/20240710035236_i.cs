using System;
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
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<bool>(type: "bit", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hobbies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dislikes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuisines = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sports = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    College = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Work_Status = table.Column<int>(type: "int", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organisation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subcription_id = table.Column<int>(type: "int", nullable: false),
                    SubscriptionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Contact",
                columns: table => new
                {
                    contact_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.contact_id);
                    table.ForeignKey(
                        name: "FK_Contact_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Friend_Id = table.Column<int>(type: "int", nullable: false),
                    isAccepted = table.Column<bool>(type: "bit", nullable: false),
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
                    { 1, 5, new DateTime(2024, 7, 10, 10, 52, 36, 74, DateTimeKind.Local).AddTicks(6787), "Chat Free", 0m, new DateTime(2024, 7, 11, 10, 52, 36, 74, DateTimeKind.Local).AddTicks(6792) },
                    { 2, -1, new DateTime(2024, 7, 10, 10, 52, 36, 74, DateTimeKind.Local).AddTicks(6795), "Unlimited Chat (1 day)", 1m, new DateTime(2024, 7, 11, 10, 52, 36, 74, DateTimeKind.Local).AddTicks(6796) },
                    { 3, -1, new DateTime(2024, 7, 10, 10, 52, 36, 74, DateTimeKind.Local).AddTicks(6797), "Unlimited Chat (1 month)", 5m, new DateTime(2024, 8, 10, 10, 52, 36, 74, DateTimeKind.Local).AddTicks(6798) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "User_id", "Address", "Balance", "College", "ConfirmationCode", "CreatedAt", "Cuisines", "DOB", "Designation", "Dislikes", "Email", "Fullname", "Hobbies", "Image", "IsEmailConfirmed", "Likes", "MaritalStatus", "Organisation", "Password", "Phone_Number", "Qualifications", "School", "Sports", "Subcription_id", "SubscriptionEndDate", "SubscriptionId", "UpdatedAt", "User_name", "Work_Status", "gender" },
                values: new object[,]
                {
                    { 1, "3560 Armstrong Well", 0m, "Mayer LLC", null, new DateTime(2024, 7, 10, 3, 52, 36, 71, DateTimeKind.Utc).AddTicks(4518), "food", new DateTime(2024, 7, 10, 10, 52, 36, 71, DateTimeKind.Local).AddTicks(7598), "1", "quia, voluptatem, aliquam", "ElisabethSr.@gmail.com", "Cletus Powlowski", "deserunt, tempora, quisquam", "11.jpg", true, "accusamus, voluptas, pariatur", false, "Williamson Group", "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "116-131-4006 x051", "Bachelor's Degree", "Sample High School", "soccer", 1, new DateTime(2024, 7, 11, 10, 52, 36, 71, DateTimeKind.Local).AddTicks(8441), null, new DateTime(2024, 7, 10, 3, 52, 36, 71, DateTimeKind.Utc).AddTicks(4521), "Velma", 0, 1 },
                    { 2, "46099 Timmothy Neck", 0m, "Borer, Heaney and Homenick", null, new DateTime(2024, 7, 10, 3, 52, 36, 71, DateTimeKind.Utc).AddTicks(8456), "food", new DateTime(2024, 7, 10, 10, 52, 36, 72, DateTimeKind.Local).AddTicks(1533), "1", "dolor, tempora, rerum", "LazaroIII@gmail.com", "Waylon Smitham", "sit, consequatur, porro", "6.png", true, "modi, nemo, velit", false, "Runolfsdottir, Feil and Jakubowski", "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "310-796-7463 x392", "Bachelor's Degree", "Sample High School", "soccer", 1, new DateTime(2024, 7, 11, 10, 52, 36, 72, DateTimeKind.Local).AddTicks(2876), null, new DateTime(2024, 7, 10, 3, 52, 36, 71, DateTimeKind.Utc).AddTicks(8456), "Rosendo", 0, 2 },
                    { 3, "2149 Conner Streets", 0m, "Hermiston Group", null, new DateTime(2024, 7, 10, 3, 52, 36, 72, DateTimeKind.Utc).AddTicks(2877), "food", new DateTime(2024, 7, 10, 10, 52, 36, 72, DateTimeKind.Local).AddTicks(7887), "1", "voluptas, delectus, non", "HarveyV@gmail.com", "Dr. Herminio Kunze", "voluptas, omnis, et", "6.png", true, "quidem, omnis, aut", false, "Konopelski Inc and Sons", "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "(553)388-7422 x916", "Bachelor's Degree", "Sample High School", "soccer", 1, new DateTime(2024, 7, 11, 10, 52, 36, 72, DateTimeKind.Local).AddTicks(8644), null, new DateTime(2024, 7, 10, 3, 52, 36, 72, DateTimeKind.Utc).AddTicks(2878), "Winston", 1, 1 },
                    { 4, "793 Lavonne Mall", 0m, "Heller, Jones and Bins", null, new DateTime(2024, 7, 10, 3, 52, 36, 72, DateTimeKind.Utc).AddTicks(8652), "food", new DateTime(2024, 7, 10, 10, 52, 36, 73, DateTimeKind.Local).AddTicks(1605), "1", "dolorum, est, ab", "CamilaII@gmail.com", "Kaley Walker", "rerum, sed, earum", "7.jpg", true, "ut, placeat, iure", false, "Reinger, Lakin and Collins", "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "(865)489-1855 x5812", "Bachelor's Degree", "Sample High School", "soccer", 1, new DateTime(2024, 7, 11, 10, 52, 36, 73, DateTimeKind.Local).AddTicks(2761), null, new DateTime(2024, 7, 10, 3, 52, 36, 72, DateTimeKind.Utc).AddTicks(8652), "Mackenzie", 2, 1 },
                    { 5, "5761 Shanelle Valley", 0m, "Becker-Schultz", null, new DateTime(2024, 7, 10, 3, 52, 36, 73, DateTimeKind.Utc).AddTicks(2764), "food", new DateTime(2024, 7, 10, 10, 52, 36, 73, DateTimeKind.Local).AddTicks(5810), "1", "minus, et, adipisci", "OzellaSr.@gmail.com", "Shany Schimmel", "nobis, ea, corrupti", "6.png", true, "consequatur, voluptates, non", false, "Kovacek LLC", "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "1-499-037-9087 x876", "Bachelor's Degree", "Sample High School", "soccer", 1, new DateTime(2024, 7, 11, 10, 52, 36, 73, DateTimeKind.Local).AddTicks(6829), null, new DateTime(2024, 7, 10, 3, 52, 36, 73, DateTimeKind.Utc).AddTicks(2764), "Orval", 2, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_User_id",
                table: "Contact",
                column: "User_id");

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
                name: "Contact");

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
