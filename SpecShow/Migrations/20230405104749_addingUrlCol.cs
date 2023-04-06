using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpecShow.Migrations
{
    /// <inheritdoc />
    public partial class addingUrlCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AmazonUrl",
                table: "Mobile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FlipkartUrl",
                table: "Mobile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmazonUrl",
                table: "Mobile");

            migrationBuilder.DropColumn(
                name: "FlipkartUrl",
                table: "Mobile");
        }
    }
}
