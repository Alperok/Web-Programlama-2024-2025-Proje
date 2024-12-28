using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforProg.Migrations
{
    /// <inheritdoc />
    public partial class AddRandevuSystemLINQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "BarberServices",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BarberServices_PersonelId",
                table: "BarberServices",
                column: "PersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BarberServices_Personel_PersonelId",
                table: "BarberServices",
                column: "PersonelId",
                principalTable: "Personel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberServices_Personel_PersonelId",
                table: "BarberServices");

            migrationBuilder.DropIndex(
                name: "IX_BarberServices_PersonelId",
                table: "BarberServices");

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "BarberServices");
        }
    }
}
