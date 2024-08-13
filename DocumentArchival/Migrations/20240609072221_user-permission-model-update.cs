using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentArchival.Migrations
{
    /// <inheritdoc />
    public partial class userpermissionmodelupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fil08User_Permissions_emp01employees_fil08dep01uin",
                table: "fil08User_Permissions");

            migrationBuilder.RenameColumn(
                name: "fil08dep01uin",
                table: "fil08User_Permissions",
                newName: "fil08emp01uin");

            migrationBuilder.RenameIndex(
                name: "IX_fil08User_Permissions_fil08dep01uin",
                table: "fil08User_Permissions",
                newName: "IX_fil08User_Permissions_fil08emp01uin");

            migrationBuilder.AddForeignKey(
                name: "FK_fil08User_Permissions_emp01employees_fil08emp01uin",
                table: "fil08User_Permissions",
                column: "fil08emp01uin",
                principalTable: "emp01employees",
                principalColumn: "emp01uin",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fil08User_Permissions_emp01employees_fil08emp01uin",
                table: "fil08User_Permissions");

            migrationBuilder.RenameColumn(
                name: "fil08emp01uin",
                table: "fil08User_Permissions",
                newName: "fil08dep01uin");

            migrationBuilder.RenameIndex(
                name: "IX_fil08User_Permissions_fil08emp01uin",
                table: "fil08User_Permissions",
                newName: "IX_fil08User_Permissions_fil08dep01uin");

            migrationBuilder.AddForeignKey(
                name: "FK_fil08User_Permissions_emp01employees_fil08dep01uin",
                table: "fil08User_Permissions",
                column: "fil08dep01uin",
                principalTable: "emp01employees",
                principalColumn: "emp01uin",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
