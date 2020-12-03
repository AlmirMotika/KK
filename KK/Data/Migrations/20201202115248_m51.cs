using Microsoft.EntityFrameworkCore.Migrations;

namespace KK.Data.Migrations
{
    public partial class m51 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserID",
                table: "Prodaje",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Prodaje",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "Kartas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prodaje_ApplicationUserId",
                table: "Prodaje",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Kartas_ApplicationUserID",
                table: "Kartas",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kartas_AspNetUsers_ApplicationUserID",
                table: "Kartas",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prodaje_AspNetUsers_ApplicationUserId",
                table: "Prodaje",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kartas_AspNetUsers_ApplicationUserID",
                table: "Kartas");

            migrationBuilder.DropForeignKey(
                name: "FK_Prodaje_AspNetUsers_ApplicationUserId",
                table: "Prodaje");

            migrationBuilder.DropIndex(
                name: "IX_Prodaje_ApplicationUserId",
                table: "Prodaje");

            migrationBuilder.DropIndex(
                name: "IX_Kartas_ApplicationUserID",
                table: "Kartas");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Prodaje");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Prodaje");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Kartas");
        }
    }
}
