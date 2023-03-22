using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberServices_Services_BarberId",
                table: "BarberServices");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberServices_Users_ServiceId",
                table: "BarberServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_BarberId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationService_BarberServices_ReservationId",
                table: "ReservationService");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationService_Reservations_ServiceId",
                table: "ReservationService");

            migrationBuilder.AddForeignKey(
                name: "FK_BarberServices_Services_BarberId",
                table: "BarberServices",
                column: "BarberId",
                principalTable: "Services",
                principalColumn: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_BarberServices_Users_ServiceId",
                table: "BarberServices",
                column: "ServiceId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_BarberId",
                table: "Reservations",
                column: "BarberId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationService_BarberServices_ReservationId",
                table: "ReservationService",
                column: "ReservationId",
                principalTable: "BarberServices",
                principalColumn: "BarberServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationService_Reservations_ServiceId",
                table: "ReservationService",
                column: "ServiceId",
                principalTable: "Reservations",
                principalColumn: "ReservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberServices_Services_BarberId",
                table: "BarberServices");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberServices_Users_ServiceId",
                table: "BarberServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_BarberId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationService_BarberServices_ReservationId",
                table: "ReservationService");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationService_Reservations_ServiceId",
                table: "ReservationService");

            migrationBuilder.AddForeignKey(
                name: "FK_BarberServices_Services_BarberId",
                table: "BarberServices",
                column: "BarberId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberServices_Users_ServiceId",
                table: "BarberServices",
                column: "ServiceId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_BarberId",
                table: "Reservations",
                column: "BarberId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationService_BarberServices_ReservationId",
                table: "ReservationService",
                column: "ReservationId",
                principalTable: "BarberServices",
                principalColumn: "BarberServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationService_Reservations_ServiceId",
                table: "ReservationService",
                column: "ServiceId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
