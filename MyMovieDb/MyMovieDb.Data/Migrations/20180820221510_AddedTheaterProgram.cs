using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovieDb.Data.Migrations
{
    public partial class AddedTheaterProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TheaterProgram",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheaterProgram", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviesInTheaters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<int>(nullable: false),
                    TheaterProgramId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesInTheaters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviesInTheaters_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesInTheaters_TheaterProgram_TheaterProgramId",
                        column: x => x.TheaterProgramId,
                        principalTable: "TheaterProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviesInTheaters_MovieId",
                table: "MoviesInTheaters",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesInTheaters_TheaterProgramId",
                table: "MoviesInTheaters",
                column: "TheaterProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviesInTheaters");

            migrationBuilder.DropTable(
                name: "TheaterProgram");
        }
    }
}
