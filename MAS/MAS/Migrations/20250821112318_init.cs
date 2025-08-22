using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MAS.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BodyType = table.Column<int>(type: "integer", nullable: false),
                    brand = table.Column<string>(type: "text", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    productionYear = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    roofType = table.Column<int>(type: "integer", nullable: false),
                    numberOfPassangers = table.Column<int>(type: "integer", nullable: false),
                    timeToGoundred = table.Column<double>(type: "double precision", nullable: true),
                    drive4x4 = table.Column<bool>(type: "boolean", nullable: true),
                    offRoad = table.Column<bool>(type: "boolean", nullable: true),
                    dailyRate = table.Column<double>(type: "double precision", nullable: false),
                    deposit = table.Column<double>(type: "double precision", nullable: false),
                    condition = table.Column<string>(type: "text", nullable: false),
                    mileage = table.Column<double>(type: "double precision", nullable: false),
                    CarType = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    range = table.Column<double>(type: "double precision", nullable: true),
                    fuelConsumption = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    personId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phoneNumber = table.Column<string>(type: "text", nullable: false),
                    personTypes = table.Column<int>(type: "integer", nullable: false),
                    hourlyRate = table.Column<double>(type: "double precision", nullable: true),
                    registrationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    id = table.Column<string>(type: "text", nullable: true),
                    idNumber = table.Column<string>(type: "text", nullable: true),
                    drivingLicense = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.personId);
                });

            migrationBuilder.CreateTable(
                name: "CarPerson",
                columns: table => new
                {
                    preparationsid = table.Column<int>(type: "integer", nullable: false),
                    preparedpersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPerson", x => new { x.preparationsid, x.preparedpersonId });
                    table.ForeignKey(
                        name: "FK_CarPerson_Cars_preparationsid",
                        column: x => x.preparationsid,
                        principalTable: "Cars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarPerson_Persons_preparedpersonId",
                        column: x => x.preparedpersonId,
                        principalTable: "Persons",
                        principalColumn: "personId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    rentalId = table.Column<int>(type: "integer", nullable: false),
                    contractNumber = table.Column<bool>(type: "boolean", nullable: false),
                    contractDate = table.Column<DateOnly>(type: "date", nullable: false),
                    deposit = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.rentalId);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rentalDate = table.Column<DateOnly>(type: "date", nullable: false),
                    returnDate = table.Column<DateOnly>(type: "date", nullable: true),
                    rentalStartMileage = table.Column<double>(type: "double precision", nullable: false),
                    kilometersDriven = table.Column<double>(type: "double precision", nullable: true),
                    vehicleConditionAtStart = table.Column<string>(type: "text", nullable: false),
                    vehicleConditionAfterReturn = table.Column<string>(type: "text", nullable: true),
                    totalCost = table.Column<double>(type: "double precision", nullable: true),
                    penalty = table.Column<double>(type: "double precision", nullable: true),
                    rentalStatus = table.Column<int>(type: "integer", nullable: false),
                    preparedByEmployeepersonId = table.Column<int>(type: "integer", nullable: false),
                    handledByEmployeepersonId = table.Column<int>(type: "integer", nullable: false),
                    isPrepared = table.Column<bool>(type: "boolean", nullable: false),
                    reservationId = table.Column<int>(type: "integer", nullable: false),
                    contractId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rentals_Contracts_contractId",
                        column: x => x.contractId,
                        principalTable: "Contracts",
                        principalColumn: "rentalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Persons_handledByEmployeepersonId",
                        column: x => x.handledByEmployeepersonId,
                        principalTable: "Persons",
                        principalColumn: "personId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Persons_preparedByEmployeepersonId",
                        column: x => x.preparedByEmployeepersonId,
                        principalTable: "Persons",
                        principalColumn: "personId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dateOfReservation = table.Column<DateOnly>(type: "date", nullable: false),
                    reservationStatus = table.Column<int>(type: "integer", nullable: false),
                    numberOfDays = table.Column<int>(type: "integer", nullable: false),
                    reason = table.Column<string>(type: "text", nullable: true),
                    deposit = table.Column<bool>(type: "boolean", nullable: false),
                    personId = table.Column<int>(type: "integer", nullable: false),
                    carId = table.Column<int>(type: "integer", nullable: false),
                    rentalId = table.Column<int>(type: "integer", nullable: false),
                    satisfactionSurveyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reservations_Cars_carId",
                        column: x => x.carId,
                        principalTable: "Cars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Persons_personId",
                        column: x => x.personId,
                        principalTable: "Persons",
                        principalColumn: "personId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Rentals_rentalId",
                        column: x => x.rentalId,
                        principalTable: "Rentals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SatisfactionSurveys",
                columns: table => new
                {
                    reservationId = table.Column<int>(type: "integer", nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    customerpersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisfactionSurveys", x => x.reservationId);
                    table.ForeignKey(
                        name: "FK_SatisfactionSurveys_Persons_customerpersonId",
                        column: x => x.customerpersonId,
                        principalTable: "Persons",
                        principalColumn: "personId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SatisfactionSurveys_Reservations_reservationId",
                        column: x => x.reservationId,
                        principalTable: "Reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "id", "BodyType", "CarType", "brand", "condition", "dailyRate", "deposit", "drive4x4", "mileage", "model", "numberOfPassangers", "offRoad", "productionYear", "roofType", "timeToGoundred" },
                values: new object[] { 1, 2, "Hybrid", "Toyota", "Good", 200.0, 1000.0, true, 35000.0, "RAV4", 5, true, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "id", "BodyType", "CarType", "brand", "condition", "dailyRate", "deposit", "drive4x4", "mileage", "model", "numberOfPassangers", "offRoad", "productionYear", "range", "roofType", "timeToGoundred" },
                values: new object[] { 2, 8, "Electric", "Tesla", "Excellent", 300.0, 1500.0, null, 15000.0, "Model 3", 5, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 0, 3.5 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "id", "BodyType", "CarType", "brand", "condition", "dailyRate", "deposit", "drive4x4", "fuelConsumption", "mileage", "model", "numberOfPassangers", "offRoad", "productionYear", "roofType", "timeToGoundred" },
                values: new object[] { 3, 1, "InternalCombusion", "Ford", "Used", 180.0, 800.0, null, 0.0, 120000.0, "Transit", 9, null, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "personId", "dateOfBirth", "drivingLicense", "email", "hourlyRate", "id", "idNumber", "name", "personTypes", "phoneNumber", "registrationDate", "surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "jan.kowalski@example.com", null, "PERSON/2025/1", "ABC123", "Jan", 2, "123456789", new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kowalski" },
                    { 2, new DateTime(1985, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "ewa.nowak@example.com", 40.0, null, null, "Ewa", 1, "987654321", null, "Nowak" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarPerson_preparedpersonId",
                table: "CarPerson",
                column: "preparedpersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_contractId",
                table: "Rentals",
                column: "contractId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_handledByEmployeepersonId",
                table: "Rentals",
                column: "handledByEmployeepersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_preparedByEmployeepersonId",
                table: "Rentals",
                column: "preparedByEmployeepersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_reservationId",
                table: "Rentals",
                column: "reservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_carId",
                table: "Reservations",
                column: "carId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_personId",
                table: "Reservations",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_rentalId",
                table: "Reservations",
                column: "rentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_satisfactionSurveyId",
                table: "Reservations",
                column: "satisfactionSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SatisfactionSurveys_customerpersonId",
                table: "SatisfactionSurveys",
                column: "customerpersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Rentals_rentalId",
                table: "Contracts",
                column: "rentalId",
                principalTable: "Rentals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Reservations_reservationId",
                table: "Rentals",
                column: "reservationId",
                principalTable: "Reservations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_SatisfactionSurveys_satisfactionSurveyId",
                table: "Reservations",
                column: "satisfactionSurveyId",
                principalTable: "SatisfactionSurveys",
                principalColumn: "reservationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Cars_carId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Persons_handledByEmployeepersonId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Persons_preparedByEmployeepersonId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Persons_personId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_SatisfactionSurveys_Persons_customerpersonId",
                table: "SatisfactionSurveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Rentals_rentalId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rentals_rentalId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_SatisfactionSurveys_Reservations_reservationId",
                table: "SatisfactionSurveys");

            migrationBuilder.DropTable(
                name: "CarPerson");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "SatisfactionSurveys");
        }
    }
}
