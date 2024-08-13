using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentArchival.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fil02Document_Details_fil09document_type_fil02fil09uin",
                table: "fil02Document_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_fil02Document_Details_fil10document_category_fil02fil10uin",
                table: "fil02Document_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_fil10document_category_fil09document_type_fil10fil09uin",
                table: "fil10document_category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fil10document_category",
                table: "fil10document_category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fil09document_type",
                table: "fil09document_type");

            migrationBuilder.RenameTable(
                name: "fil10document_category",
                newName: "fil10document_categories");

            migrationBuilder.RenameTable(
                name: "fil09document_type",
                newName: "fil09document_types");

            migrationBuilder.RenameIndex(
                name: "IX_fil10document_category_fil10fil09uin",
                table: "fil10document_categories",
                newName: "IX_fil10document_categories_fil10fil09uin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fil10document_categories",
                table: "fil10document_categories",
                column: "fil10uin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fil09document_types",
                table: "fil09document_types",
                column: "fil09uin");

            migrationBuilder.AddForeignKey(
                name: "FK_fil02Document_Details_fil09document_types_fil02fil09uin",
                table: "fil02Document_Details",
                column: "fil02fil09uin",
                principalTable: "fil09document_types",
                principalColumn: "fil09uin",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_fil02Document_Details_fil10document_categories_fil02fil10uin",
                table: "fil02Document_Details",
                column: "fil02fil10uin",
                principalTable: "fil10document_categories",
                principalColumn: "fil10uin",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_fil10document_categories_fil09document_types_fil10fil09uin",
                table: "fil10document_categories",
                column: "fil10fil09uin",
                principalTable: "fil09document_types",
                principalColumn: "fil09uin",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fil02Document_Details_fil09document_types_fil02fil09uin",
                table: "fil02Document_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_fil02Document_Details_fil10document_categories_fil02fil10uin",
                table: "fil02Document_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_fil10document_categories_fil09document_types_fil10fil09uin",
                table: "fil10document_categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fil10document_categories",
                table: "fil10document_categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fil09document_types",
                table: "fil09document_types");

            migrationBuilder.RenameTable(
                name: "fil10document_categories",
                newName: "fil10document_category");

            migrationBuilder.RenameTable(
                name: "fil09document_types",
                newName: "fil09document_type");

            migrationBuilder.RenameIndex(
                name: "IX_fil10document_categories_fil10fil09uin",
                table: "fil10document_category",
                newName: "IX_fil10document_category_fil10fil09uin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fil10document_category",
                table: "fil10document_category",
                column: "fil10uin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fil09document_type",
                table: "fil09document_type",
                column: "fil09uin");

            migrationBuilder.AddForeignKey(
                name: "FK_fil02Document_Details_fil09document_type_fil02fil09uin",
                table: "fil02Document_Details",
                column: "fil02fil09uin",
                principalTable: "fil09document_type",
                principalColumn: "fil09uin",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fil02Document_Details_fil10document_category_fil02fil10uin",
                table: "fil02Document_Details",
                column: "fil02fil10uin",
                principalTable: "fil10document_category",
                principalColumn: "fil10uin",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fil10document_category_fil09document_type_fil10fil09uin",
                table: "fil10document_category",
                column: "fil10fil09uin",
                principalTable: "fil09document_type",
                principalColumn: "fil09uin",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
