using Microsoft.EntityFrameworkCore.Migrations;

namespace A.NETLabb4.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    HobbyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HobbyName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.HobbyID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Adress = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserHobbies",
                columns: table => new
                {
                    UserHobbyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    HobbyID = table.Column<int>(nullable: false),
                    WebsiteLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHobbies", x => x.UserHobbyID);
                    table.ForeignKey(
                        name: "FK_UserHobbies_Hobbies_HobbyID",
                        column: x => x.HobbyID,
                        principalTable: "Hobbies",
                        principalColumn: "HobbyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHobbies_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "HobbyID", "Description", "HobbyName" },
                values: new object[,]
                {
                    { 1, "Painting is the practice of applying paint, pigment, color or other medium to a solid surface.", "Painting" },
                    { 2, "Dance is a performing art form consisting of sequences of movement, either improvised or purposefully selected.", "Dance" },
                    { 3, "Soccer is a sport where the objective is to score in the opposite teams goal.", "Soccer" },
                    { 4, "Karate is a martial art developed in the Ryukyu Kingdom.", "Karate" },
                    { 5, "Swimming is the self-propulsion of a person through water, or other liquid, usually for recreation, sport, exercise, or survival.", "Swimming" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Adress", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Storgatan 16", "Hanna Lahtinen", "0738987647" },
                    { 2, "Nyhemsgatan 11", "Jennifer Gergi", "0729098478" },
                    { 3, "Storgatan 2", "Karl Levin", "0737645387" }
                });

            migrationBuilder.InsertData(
                table: "UserHobbies",
                columns: new[] { "UserHobbyID", "HobbyID", "UserID", "WebsiteLink" },
                values: new object[,]
                {
                    { 1, 1, 1, "https://www.britannica.com/art/painting" },
                    { 2, 2, 1, "https://justdancenow.com/?msclkid=a6db88d8a6f011ecb496d62156d715c2" },
                    { 3, 3, 2, "https://nr.soccerway.com/?msclkid=c254e7a3a6f011ecbe9cf1576f5c8b26" },
                    { 4, 4, 3, "https://www.karate.com/?msclkid=033d5163a6f111ecbd04e11c109355de" },
                    { 5, 5, 3, "https://www.swimmingworldmagazine.com/news/the-2022-ncaa-womens-championships-day-2-finals-500-freestyle?msclkid=10132017a6f111ecba5147ba639fac7f" },
                    { 6, 5, 3, "https://www.swimming.org/?msclkid=94a037dca6f111ecbfe16cc89f8fcbb2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserHobbies_HobbyID",
                table: "UserHobbies",
                column: "HobbyID");

            migrationBuilder.CreateIndex(
                name: "IX_UserHobbies_UserID",
                table: "UserHobbies",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserHobbies");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
