using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentAll_WebAPIs.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    passwordhash = table.Column<string>(type: "TEXT", nullable: false),
                    role = table.Column<string>(type: "TEXT", nullable: false),
                    createdat = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ownerid = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    dailyrate = table.Column<decimal>(type: "TEXT", nullable: false),
                    isavailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    createdat = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment", x => x.id);
                    table.ForeignKey(
                        name: "FK_equipment_users_ownerid",
                        column: x => x.ownerid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    equipmentid = table.Column<int>(type: "INTEGER", nullable: false),
                    rentername = table.Column<string>(type: "TEXT", nullable: false),
                    startdate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    enddate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    totaldays = table.Column<int>(type: "INTEGER", nullable: false),
                    totalprice = table.Column<decimal>(type: "TEXT", nullable: false),
                    depositamount = table.Column<decimal>(type: "TEXT", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    createdat = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.id);
                    table.ForeignKey(
                        name: "FK_bookings_equipment_equipmentid",
                        column: x => x.equipmentid,
                        principalTable: "equipment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookingstatushistories",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    bookingid = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    changedat = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingstatushistories", x => x.id);
                    table.ForeignKey(
                        name: "FK_bookingstatushistories_bookings_bookingid",
                        column: x => x.bookingid,
                        principalTable: "bookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_equipmentid",
                table: "bookings",
                column: "equipmentid");

            migrationBuilder.CreateIndex(
                name: "IX_bookingstatushistories_bookingid",
                table: "bookingstatushistories",
                column: "bookingid");

            migrationBuilder.CreateIndex(
                name: "IX_equipment_ownerid",
                table: "equipment",
                column: "ownerid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingstatushistories");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "equipment");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
