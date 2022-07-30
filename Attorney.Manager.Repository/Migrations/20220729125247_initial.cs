using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attorney.Manager.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "commercial_adress",
                columns: table => new
                {
                    commercial_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    postal_code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    street_name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(125)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commercial_adress", x => x.commercial_id);
                });

            migrationBuilder.CreateTable(
                name: "attorney",
                columns: table => new
                {
                    attoreny_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    commercial_adress_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attorney", x => x.attoreny_id);
                    table.ForeignKey(
                        name: "FK_attorney_commercial_adress_commercial_adress_id",
                        column: x => x.commercial_adress_id,
                        principalTable: "commercial_adress",
                        principalColumn: "commercial_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seniority",
                columns: table => new
                {
                    seniority_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    seniority = table.Column<int>(type: "INT", nullable: false),
                    attorney_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seniority", x => x.seniority_id);
                    table.ForeignKey(
                        name: "FK_Seniority_attorney_attorney_id",
                        column: x => x.attorney_id,
                        principalTable: "attorney",
                        principalColumn: "attoreny_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attorney_commercial_adress_id",
                table: "attorney",
                column: "commercial_adress_id");

            migrationBuilder.CreateIndex(
                name: "IX_Seniority_attorney_id",
                table: "Seniority",
                column: "attorney_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seniority");

            migrationBuilder.DropTable(
                name: "attorney");

            migrationBuilder.DropTable(
                name: "commercial_adress");
        }
    }
}
