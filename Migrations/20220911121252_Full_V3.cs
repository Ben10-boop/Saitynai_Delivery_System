using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saitynai_Delivery_System1.Migrations
{
    public partial class Full_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Vehicles_VehicleId",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Packages",
                newName: "DeliveryVehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_VehicleId",
                table: "Packages",
                newName: "IX_Packages_DeliveryVehicleId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Vehicles_DeliveryVehicleId",
                table: "Packages",
                column: "DeliveryVehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Vehicles_DeliveryVehicleId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "DeliveryVehicleId",
                table: "Packages",
                newName: "VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_DeliveryVehicleId",
                table: "Packages",
                newName: "IX_Packages_VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Vehicles_VehicleId",
                table: "Packages",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
