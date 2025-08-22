using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_SatisfactionSurveys_satisfactionSurveyId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_SatisfactionSurveys_Persons_customerpersonId",
                table: "SatisfactionSurveys");

            migrationBuilder.DropIndex(
                name: "IX_SatisfactionSurveys_customerpersonId",
                table: "SatisfactionSurveys");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_satisfactionSurveyId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "customerpersonId",
                table: "SatisfactionSurveys");

            migrationBuilder.DropColumn(
                name: "satisfactionSurveyId",
                table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "customerpersonId",
                table: "SatisfactionSurveys",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "satisfactionSurveyId",
                table: "Reservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SatisfactionSurveys_customerpersonId",
                table: "SatisfactionSurveys",
                column: "customerpersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_satisfactionSurveyId",
                table: "Reservations",
                column: "satisfactionSurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_SatisfactionSurveys_satisfactionSurveyId",
                table: "Reservations",
                column: "satisfactionSurveyId",
                principalTable: "SatisfactionSurveys",
                principalColumn: "reservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SatisfactionSurveys_Persons_customerpersonId",
                table: "SatisfactionSurveys",
                column: "customerpersonId",
                principalTable: "Persons",
                principalColumn: "personId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
