using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rentals_rentalId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "rentalId",
                table: "Reservations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rentals_rentalId",
                table: "Reservations",
                column: "rentalId",
                principalTable: "Rentals",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rentals_rentalId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "rentalId",
                table: "Reservations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rentals_rentalId",
                table: "Reservations",
                column: "rentalId",
                principalTable: "Rentals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
