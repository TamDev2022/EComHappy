using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTokenEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTimeAccessToken",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "StartTimeAccessToken",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "StartTimeRefreshToken",
                table: "Token");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndTimeAccessToken",
                table: "Token",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartTimeAccessToken",
                table: "Token",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartTimeRefreshToken",
                table: "Token",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
