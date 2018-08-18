using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovieDb.Data.Migrations
{
    public partial class MoviePlotRemovedMaxLengthtTrailerUrlToYoutubeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrailerVideoUrl",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "People",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1024);

            migrationBuilder.AddColumn<string>(
                name: "TrailerYoutubeId",
                table: "Movies",
                maxLength: 11,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrailerYoutubeId",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "People",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "TrailerVideoUrl",
                table: "Movies",
                nullable: true);
        }
    }
}
