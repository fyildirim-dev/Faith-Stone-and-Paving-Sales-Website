using Microsoft.EntityFrameworkCore.Migrations;

namespace First_DataAccess.Migrations
{
    public partial class addShortDescToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "shortDesc",
                table: "Product",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "shortDesc",
                table: "Product");
        }
    }
}
