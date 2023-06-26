using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AlterTablesClientAndDeliveryMan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "DeliveryMan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryMan_UserId",
                table: "DeliveryMan",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_UserId",
                table: "Client",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Users_UserId",
                table: "Client",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryMan_Users_UserId",
                table: "DeliveryMan",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Users_UserId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryMan_Users_UserId",
                table: "DeliveryMan");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryMan_UserId",
                table: "DeliveryMan");

            migrationBuilder.DropIndex(
                name: "IX_Client_UserId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DeliveryMan");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Client");
        }
    }
}
