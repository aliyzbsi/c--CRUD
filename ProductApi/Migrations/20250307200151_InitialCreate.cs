using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductStatusId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductStatusName = table.Column<string>(type: "text", nullable: false),
                    ProductUrl = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    TitleDomestic = table.Column<string>(type: "text", nullable: false),
                    DescriptionDomestic = table.Column<string>(type: "text", nullable: false),
                    Sku = table.Column<string>(type: "text", nullable: false),
                    Barcode = table.Column<string>(type: "text", nullable: false),
                    OtherCode = table.Column<string>(type: "text", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    CurrencyName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PriceDiscountedDomestic = table.Column<decimal>(type: "numeric", nullable: false),
                    PriceDiscounted = table.Column<decimal>(type: "numeric", nullable: false),
                    IsFeatured = table.Column<bool>(type: "boolean", nullable: false),
                    IsElonkyFeatured = table.Column<bool>(type: "boolean", nullable: false),
                    HasVideo = table.Column<bool>(type: "boolean", nullable: false),
                    HasPersonalization = table.Column<bool>(type: "boolean", nullable: false),
                    IsTaxable = table.Column<bool>(type: "boolean", nullable: false),
                    WhenMade = table.Column<string>(type: "text", nullable: false),
                    WhoMade = table.Column<string>(type: "text", nullable: false),
                    PersonalizationDescription = table.Column<string>(type: "text", nullable: false),
                    IsDigital = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductStatusId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
