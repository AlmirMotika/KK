using Microsoft.EntityFrameworkCore.Migrations;

namespace KK.Data.Migrations
{
    public partial class m22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodaje_AspNetUsers_ApplicationUserId",
                table: "Prodaje");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Prodaje");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Prodaje",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Prodaje_ApplicationUserId",
                table: "Prodaje",
                newName: "IX_Prodaje_ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodaje_AspNetUsers_ApplicationUserID",
                table: "Prodaje",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodaje_AspNetUsers_ApplicationUserID",
                table: "Prodaje");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Prodaje",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Prodaje_ApplicationUserID",
                table: "Prodaje",
                newName: "IX_Prodaje_ApplicationUserId");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserID",
                table: "Prodaje",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Prodaje_AspNetUsers_ApplicationUserId",
                table: "Prodaje",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
