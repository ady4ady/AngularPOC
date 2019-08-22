using Microsoft.EntityFrameworkCore.Migrations;

namespace CarOrderingWebApi.Migrations
{
    public partial class ordertablechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Cars_CarId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Register_RegistrationId",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "RegistrationId",
                table: "Order",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Order",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Cars_CarId",
                table: "Order",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Register_RegistrationId",
                table: "Order",
                column: "RegistrationId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Cars_CarId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Register_RegistrationId",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "RegistrationId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Cars_CarId",
                table: "Order",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Register_RegistrationId",
                table: "Order",
                column: "RegistrationId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
