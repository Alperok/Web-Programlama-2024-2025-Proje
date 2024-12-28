using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KuaforProg.Migrations
{
    /// <inheritdoc />
    public partial class AddRandevuSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abilities",
                table: "Personel");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "Personel");

            migrationBuilder.DropColumn(
                name: "Services",
                table: "Barbers");

            migrationBuilder.CreateTable(
                name: "BarberServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    BarberId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarberServices_Barbers_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonelServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonelId = table.Column<int>(type: "integer", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    BarberServiceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonelServices_BarberServices_BarberServiceId",
                        column: x => x.BarberServiceId,
                        principalTable: "BarberServices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonelServices_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonelId = table.Column<int>(type: "integer", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    BarberServiceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Randevu_BarberServices_BarberServiceId",
                        column: x => x.BarberServiceId,
                        principalTable: "BarberServices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Randevu_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarberServices_BarberId",
                table: "BarberServices",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelServices_BarberServiceId",
                table: "PersonelServices",
                column: "BarberServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelServices_PersonelId",
                table: "PersonelServices",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_BarberServiceId",
                table: "Randevu",
                column: "BarberServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_PersonelId",
                table: "Randevu",
                column: "PersonelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonelServices");

            migrationBuilder.DropTable(
                name: "Randevu");

            migrationBuilder.DropTable(
                name: "BarberServices");

            migrationBuilder.AddColumn<string>(
                name: "Abilities",
                table: "Personel",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "Personel",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "Services",
                table: "Barbers",
                type: "text[]",
                nullable: true);
        }
    }
}
