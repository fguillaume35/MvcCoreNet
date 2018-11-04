using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCCoreNet.Migrations
{
    public partial class MIG_ModificationLibEtCategorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Information",
                table: "Lib",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Tag",
                table: "Categorie",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Lien_IdLib",
                table: "Lien",
                column: "IdLib");

            migrationBuilder.AddForeignKey(
                name: "FK_Lien_Lib_IdLib",
                table: "Lien",
                column: "IdLib",
                principalTable: "Lib",
                principalColumn: "IdLib",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lien_Lib_IdLib",
                table: "Lien");

            migrationBuilder.DropIndex(
                name: "IX_Lien_IdLib",
                table: "Lien");

            migrationBuilder.DropColumn(
                name: "Information",
                table: "Lib");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Categorie");
        }
    }
}
