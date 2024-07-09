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
                    { 1, 5, new DateTime(2024, 7, 9, 13, 24, 8, 731, DateTimeKind.Local).AddTicks(1823), "Chat Free", 0m, new DateTime(2024, 7, 10, 13, 24, 8, 731, DateTimeKind.Local).AddTicks(1830) },
                    { 2, -1, new DateTime(2024, 7, 9, 13, 24, 8, 731, DateTimeKind.Local).AddTicks(1835), "Unlimited Chat (1 day)", 1m, new DateTime(2024, 7, 10, 13, 24, 8, 731, DateTimeKind.Local).AddTicks(1836) },
                    { 3, -1, new DateTime(2024, 7, 9, 13, 24, 8, 731, DateTimeKind.Local).AddTicks(1837), "Unlimited Chat (1 month)", 5m, new DateTime(2024, 8, 9, 13, 24, 8, 731, DateTimeKind.Local).AddTicks(1838) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "User_id", "Address", "Balance", "College", "ConfirmationCode", "CreatedAt", "Cuisines", "DOB", "Designation", "Dislikes", "Email", "Fullname", "Hobbies", "Image", "IsEmailConfirmed", "Likes", "MaritalStatus", "Organisation", "Password", "Phone_Number", "Qualifications", "School", "Sports", "Subcription_id", "SubscriptionEndDate", "SubscriptionId", "UpdatedAt", "User_name", "Work_Status", "gender" },
                values: new object[,]
                {
                    { 1, "7299 Arnold Turnpike", 0m, "Gottlieb, Dietrich and Denesik", null, new DateTime(2024, 7, 9, 6, 24, 8, 727, DateTimeKind.Utc).AddTicks(3374), "food", new DateTime(2024, 7, 9, 13, 24, 8, 727, DateTimeKind.Local).AddTicks(7576), "1", "quaerat, dignissimos, non", "AldaJr.@gmail.com", "Lester Cruickshank", "iusto, et, sunt", "6.png", true, "quibusdam, id, est", false, "Flatley-West", "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "847-199-9227 x01637", "Bachelor's Degree", "Sample High School", "soccer", 1, new DateTime(2024, 7, 10, 13, 24, 8, 727, DateTimeKind.Local).AddTicks(9078), null, new DateTime(2024, 7, 9, 6, 24, 8, 727, DateTimeKind.Utc).AddTicks(3382), "Allie", 1, 1 },
                    { 2, "4585 Schaefer Turnpike", 0m, "Schamberger Group", null, new DateTime(2024, 7, 9, 6, 24, 8, 727, DateTimeKind.Utc).AddTicks(9095), "food", new DateTime(2024, 7, 9, 13, 24, 8, 728, DateTimeKind.Local).AddTicks(3967), "1", "temporibus, sed, commodi", "MonserratPhD@gmail.com", "Mrs. Johnny Goodwin", "fugiat, sed, ad", "7.jpg", true, "corporis, porro, perspiciatis", false, "Runolfsdottir-Borer", "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "1-588-935-8289", "Bachelor's Degree", "Sample High School", "soccer", 1, new DateTime(2024, 7, 10, 13, 24, 8, 728, DateTimeKind.Local).AddTicks(5064), null, new DateTime(2024, 7, 9, 6, 24, 8, 727, DateTimeKind.Utc).AddTicks(9096), "Dayton", 1, 1 },
                    { 3, "23829 Ashley Spring", 0m, "Nitzsche LLC", null, new DateTime(2024, 7, 9, 6, 24, 8, 728, DateTimeKind.Utc).AddTicks(5073), "food", new DateTime(2024, 7, 9, 13, 24, 8, 728, DateTimeKind.Local).AddTicks(8313), "1", "aspernatur, aut, dolore", "JustusIV@gmail.com", "Annabel Sipes", "dolorem, ducimus, est", "11.jpg", true, "quidem, qui, necessitatibus", false, "Rohan, Windler and Heaney", "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "1-672-962-1072", "Bachelor's Degree", "Sample High School", "soccer", 1, new DateTime(2024, 7, 10, 13, 24, 8, 728, DateTimeKind.Local).AddTicks(9369), null, new DateTime(2024, 7, 9, 6, 24, 8, 728, DateTimeKind.Utc).AddTicks(5073), "Jordan", 2, 1 },
                    { 4, "63835 Brock River", 0m, "Weber-Jewess", null, new DateTime(2024, 7, 9, 6, 24, 8, 728, DateTimeKind.Utc).AddTicks(9371), "food", new DateTime(2024, 7, 9, 13, 24, 8, 729, DateTimeKind.Local).AddTicks(3024), "1", "reprehenderit, itaque, adipisci", "IsomMD@gmail.com", "Kennedy Tremblay", "dolores, quia, eaque", "10.png", true, "ullam, facilis, consectetur", false, "Roberts Inc and Sons", "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "630-784-8190 x983", "Bachelor's Degree", "Sample High School", "soccer", 1, new DateTime(2024, 7, 10, 13, 24, 8, 729, DateTimeKind.Local).AddTicks(4143), null, new DateTime(2024, 7, 9, 6, 24, 8, 728, DateTimeKind.Utc).AddTicks(9371), "Kendrick", 1, 2 },
                    { 5, "117 Flatley Bridge", 0m, "Schiller, Hammes and VonRueden", null, new DateTime(2024, 7, 9, 6, 24, 8, 729, DateTimeKind.Utc).AddTicks(4150), "food", new DateTime(2024, 7, 9, 13, 24, 8, 729, DateTimeKind.Local).AddTicks(7058), "1", "adipisci, eum, velit", "MicahDVM@gmail.com", "Reed Daugherty", "illo, earum, autem", "7.jpg", true, "ad, maxime, velit", false, "Mayert-Hudson", "$2a$12$p6SajsJcQBaDyh2eMg54huGoVjNJxUaiCcDa81dWifXKnAlBbZoVa", "1-761-465-5784 x733", "Bachelor's Degree", "Sample High School", "soccer", 1, new DateTime(2024, 7, 10, 13, 24, 8, 729, DateTimeKind.Local).AddTicks(8445), null, new DateTime(2024, 7, 9, 6, 24, 8, 729, DateTimeKind.Utc).AddTicks(4150), "Kay", 2, 0 }
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
