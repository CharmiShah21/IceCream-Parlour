using Microsoft.EntityFrameworkCore.Migrations;

namespace IceCreamParlour.Migrations
{
    public partial class Initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Distributors",
                columns: table => new
                {
                    DistributorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistributorName = table.Column<string>(nullable: true),
                    DistributorContactNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributors", x => x.DistributorId);
                });

            migrationBuilder.CreateTable(
                name: "Flavours",
                columns: table => new
                {
                    FlavourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlavourName = table.Column<string>(nullable: true),
                    FlavourDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flavours", x => x.FlavourId);
                });

            migrationBuilder.CreateTable(
                name: "IceCreams",
                columns: table => new
                {
                    IceCreamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IceCreamName = table.Column<string>(nullable: true),
                    IceCreamDescription = table.Column<string>(nullable: true),
                    IceCreamPrice = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    FlavourId = table.Column<int>(nullable: false),
                    DistributorId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IceCreams", x => x.IceCreamId);
                    table.ForeignKey(
                        name: "FK_IceCreams_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IceCreams_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IceCreams_Distributors_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Distributors",
                        principalColumn: "DistributorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IceCreams_Flavours_FlavourId",
                        column: x => x.FlavourId,
                        principalTable: "Flavours",
                        principalColumn: "FlavourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IceCreams_BrandId",
                table: "IceCreams",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_IceCreams_CategoryId",
                table: "IceCreams",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IceCreams_DistributorId",
                table: "IceCreams",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_IceCreams_FlavourId",
                table: "IceCreams",
                column: "FlavourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IceCreams");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Distributors");

            migrationBuilder.DropTable(
                name: "Flavours");
        }
    }
}
