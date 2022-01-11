using Microsoft.EntityFrameworkCore.Migrations;

namespace ARM.Movies.DataAccess.Migrations
{
    public partial class movies_db_script : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearOfRelease = table.Column<int>(type: "int", nullable: false),
                    RunningTime = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieUserRatings",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieUserRatings", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MovieUserRatings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieUserRatings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "RunningTime", "Title", "YearOfRelease" },
                values: new object[,]
                {
                    { 1, "Comedy", 157, "Movie1", 2000 },
                    { 9, "Comedy", 154, "Movie9", 2009 },
                    { 8, "Drama", 130, "Movie8", 2006 },
                    { 7, "Comedy", 172, "Movie7", 2014 },
                    { 6, "Drama", 158, "Movie6", 2003 },
                    { 10, "Drama", 157, "Movie10", 2020 },
                    { 4, "Drama", 65, "Movie4", 2013 },
                    { 3, "Comedy", 104, "Movie3", 2005 },
                    { 2, "Drama", 94, "Movie2", 2008 },
                    { 5, "Comedy", 147, "Movie5", 2019 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "user9" },
                    { 1, "user1" },
                    { 2, "user2" },
                    { 3, "user3" },
                    { 4, "user4" },
                    { 5, "user5" },
                    { 6, "user6" },
                    { 7, "user7" },
                    { 8, "user8" },
                    { 10, "user10" }
                });

            migrationBuilder.InsertData(
                table: "MovieUserRatings",
                columns: new[] { "MovieId", "UserId", "Rating" },
                values: new object[,]
                {
                    { 1, 1, 3.0 },
                    { 3, 8, 2.0 },
                    { 2, 8, 1.0 },
                    { 1, 8, 3.0 },
                    { 10, 7, 2.0 },
                    { 9, 7, 3.0 },
                    { 8, 7, 4.0 },
                    { 7, 7, 3.0 },
                    { 6, 7, 1.0 },
                    { 5, 7, 1.0 },
                    { 4, 7, 2.0 },
                    { 3, 7, 2.0 },
                    { 2, 7, 1.0 },
                    { 1, 7, 2.0 },
                    { 10, 6, 4.0 },
                    { 9, 6, 1.0 },
                    { 8, 6, 2.0 },
                    { 7, 6, 4.0 },
                    { 6, 6, 4.0 },
                    { 5, 6, 4.0 },
                    { 4, 6, 1.0 },
                    { 3, 6, 1.0 },
                    { 4, 8, 1.0 },
                    { 2, 6, 2.0 },
                    { 5, 8, 2.0 },
                    { 7, 8, 3.0 },
                    { 8, 10, 3.0 },
                    { 7, 10, 4.0 },
                    { 6, 10, 4.0 },
                    { 5, 10, 3.0 },
                    { 4, 10, 4.0 },
                    { 3, 10, 2.0 },
                    { 2, 10, 1.0 },
                    { 1, 10, 4.0 },
                    { 10, 9, 1.0 },
                    { 9, 9, 1.0 },
                    { 8, 9, 1.0 },
                    { 7, 9, 1.0 },
                    { 6, 9, 4.0 },
                    { 5, 9, 2.0 },
                    { 4, 9, 3.0 },
                    { 3, 9, 2.0 }
                });

            migrationBuilder.InsertData(
                table: "MovieUserRatings",
                columns: new[] { "MovieId", "UserId", "Rating" },
                values: new object[,]
                {
                    { 2, 9, 3.0 },
                    { 1, 9, 2.0 },
                    { 10, 8, 1.0 },
                    { 9, 8, 2.0 },
                    { 8, 8, 2.0 },
                    { 6, 8, 4.0 },
                    { 1, 6, 1.0 },
                    { 10, 5, 2.0 },
                    { 9, 5, 4.0 },
                    { 2, 3, 2.0 },
                    { 1, 3, 4.0 },
                    { 10, 2, 2.0 },
                    { 9, 2, 4.0 },
                    { 8, 2, 3.0 },
                    { 7, 2, 3.0 },
                    { 6, 2, 1.0 },
                    { 5, 2, 3.0 },
                    { 4, 2, 3.0 },
                    { 3, 2, 3.0 },
                    { 2, 2, 1.0 },
                    { 1, 2, 3.0 },
                    { 10, 1, 3.0 },
                    { 9, 1, 4.0 },
                    { 8, 1, 3.0 },
                    { 7, 1, 2.0 },
                    { 6, 1, 1.0 },
                    { 5, 1, 4.0 },
                    { 4, 1, 3.0 },
                    { 3, 1, 2.0 },
                    { 2, 1, 4.0 },
                    { 3, 3, 1.0 },
                    { 4, 3, 1.0 },
                    { 5, 3, 2.0 },
                    { 6, 3, 4.0 },
                    { 8, 5, 1.0 },
                    { 7, 5, 1.0 },
                    { 6, 5, 1.0 },
                    { 5, 5, 3.0 },
                    { 4, 5, 3.0 },
                    { 3, 5, 3.0 },
                    { 2, 5, 1.0 },
                    { 1, 5, 2.0 }
                });

            migrationBuilder.InsertData(
                table: "MovieUserRatings",
                columns: new[] { "MovieId", "UserId", "Rating" },
                values: new object[,]
                {
                    { 10, 4, 2.0 },
                    { 9, 4, 2.0 },
                    { 9, 10, 3.0 },
                    { 8, 4, 2.0 },
                    { 6, 4, 2.0 },
                    { 5, 4, 3.0 },
                    { 4, 4, 2.0 },
                    { 3, 4, 4.0 },
                    { 2, 4, 1.0 },
                    { 1, 4, 4.0 },
                    { 10, 3, 1.0 },
                    { 9, 3, 4.0 },
                    { 8, 3, 1.0 },
                    { 7, 3, 1.0 },
                    { 7, 4, 4.0 },
                    { 10, 10, 3.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieUserRatings_UserId",
                table: "MovieUserRatings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieUserRatings");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
