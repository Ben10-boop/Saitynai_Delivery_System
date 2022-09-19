using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saitynai_Delivery_System1.Migrations
{
    public partial class Full_V5_del : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Vehicles_DeliveryVehicleId",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "DeliveryVehicleId",
                table: "Packages",
                newName: "AssignedToDeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_DeliveryVehicleId",
                table: "Packages",
                newName: "IX_Packages_AssignedToDeliveryId");

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryVehicleId = table.Column<int>(type: "int", nullable: false),
                    DeliveryCourierId = table.Column<int>(type: "int", nullable: false),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Users_DeliveryCourierId",
                        column: x => x.DeliveryCourierId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_Vehicles_DeliveryVehicleId",
                        column: x => x.DeliveryVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_DeliveryCourierId",
                table: "Deliveries",
                column: "DeliveryCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_DeliveryVehicleId",
                table: "Deliveries",
                column: "DeliveryVehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Deliveries_AssignedToDeliveryId",
                table: "Packages",
                column: "AssignedToDeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Deliveries_AssignedToDeliveryId",
                table: "Packages");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.RenameColumn(
                name: "AssignedToDeliveryId",
                table: "Packages",
                newName: "DeliveryVehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_AssignedToDeliveryId",
                table: "Packages",
                newName: "IX_Packages_DeliveryVehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Vehicles_DeliveryVehicleId",
                table: "Packages",
                column: "DeliveryVehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
