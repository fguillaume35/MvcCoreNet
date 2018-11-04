using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCCoreNet.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    IdCategorie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.IdCategorie);
                });

            migrationBuilder.CreateTable(
                name: "Hebergement",
                columns: table => new
                {
                    IdHebergement = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Intitule = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    IdLib = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hebergement", x => x.IdHebergement);
                });

            migrationBuilder.CreateTable(
                name: "Lib",
                columns: table => new
                {
                    IdLib = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IdCategorie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lib", x => x.IdLib);
                });

            migrationBuilder.CreateTable(
                name: "Lien",
                columns: table => new
                {
                    IdLien = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Intitule = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    IdLib = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lien", x => x.IdLien);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Hebergement");

            migrationBuilder.DropTable(
                name: "Lib");

            migrationBuilder.DropTable(
                name: "Lien");
        }
    }
}
