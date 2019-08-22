using Microsoft.EntityFrameworkCore.Migrations;

namespace CarOrderingWebApi.Migrations
{
    public partial class orderidcodecolumntoorders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderIdCode",
                table: "Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderIdCode",
                table: "Order");
        }
    }
}
