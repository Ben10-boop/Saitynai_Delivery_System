using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saitynai_Delivery_System1.Migrations
{
    public partial class Full_V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Packages");
        }
    }
}
