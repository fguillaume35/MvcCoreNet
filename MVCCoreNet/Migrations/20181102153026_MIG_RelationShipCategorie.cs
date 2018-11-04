using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCCoreNet.Migrations
{
    public partial class MIG_RelationShipCategorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdCategorie",
                table: "Lib",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Lib_IdCategorie",
                table: "Lib",
                column: "IdCategorie");

            migrationBuilder.AddForeignKey(
                name: "FK_Lib_Categorie_IdCategorie",
                table: "Lib",
                column: "IdCategorie",
                principalTable: "Categorie",
                principalColumn: "IdCategorie",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lib_Categorie_IdCategorie",
                table: "Lib");

            migrationBuilder.DropIndex(
                name: "IX_Lib_IdCategorie",
                table: "Lib");

            migrationBuilder.AlterColumn<int>(
                name: "IdCategorie",
                table: "Lib",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
