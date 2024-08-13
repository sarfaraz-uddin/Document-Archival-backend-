using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentArchival.Migrations
{
    /// <inheritdoc />
    public partial class modelsaddedandupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fil03category",
                table: "fil03attach_documents");

            migrationBuilder.RenameColumn(
                name: "fil02doctype",
                table: "fil02Document_Details",
                newName: "fil02description");

            migrationBuilder.AddColumn<int>(
                name: "fil02fil09uin",
                table: "fil02Document_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fil02fil10uin",
                table: "fil02Document_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "fil09document_type",
                columns: table => new
                {
                    fil09uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fil09title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil09created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fil09created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil09updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fil09updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fil09document_type", x => x.fil09uin);
                });

            migrationBuilder.CreateTable(
                name: "fil10document_category",
                columns: table => new
                {
                    fil10uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fil10fil09uin = table.Column<int>(type: "int", nullable: false),
                    fil10title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil10created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fil10created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil10updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fil10updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fil10document_category", x => x.fil10uin);
                    table.ForeignKey(
                        name: "FK_fil10document_category_fil09document_type_fil10fil09uin",
                        column: x => x.fil10fil09uin,
                        principalTable: "fil09document_type",
                        principalColumn: "fil09uin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fil02Document_Details_fil02fil09uin",
                table: "fil02Document_Details",
                column: "fil02fil09uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil02Document_Details_fil02fil10uin",
                table: "fil02Document_Details",
                column: "fil02fil10uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil10document_category_fil10fil09uin",
                table: "fil10document_category",
                column: "fil10fil09uin");

            migrationBuilder.AddForeignKey(
                name: "FK_fil02Document_Details_fil09document_type_fil02fil09uin",
                table: "fil02Document_Details",
                column: "fil02fil09uin",
                principalTable: "fil09document_type",
                principalColumn: "fil09uin",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_fil02Document_Details_fil10document_category_fil02fil10uin",
                table: "fil02Document_Details",
                column: "fil02fil10uin",
                principalTable: "fil10document_category",
                principalColumn: "fil10uin",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fil02Document_Details_fil09document_type_fil02fil09uin",
                table: "fil02Document_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_fil02Document_Details_fil10document_category_fil02fil10uin",
                table: "fil02Document_Details");

            migrationBuilder.DropTable(
                name: "fil10document_category");

            migrationBuilder.DropTable(
                name: "fil09document_type");

            migrationBuilder.DropIndex(
                name: "IX_fil02Document_Details_fil02fil09uin",
                table: "fil02Document_Details");

            migrationBuilder.DropIndex(
                name: "IX_fil02Document_Details_fil02fil10uin",
                table: "fil02Document_Details");

            migrationBuilder.DropColumn(
                name: "fil02fil09uin",
                table: "fil02Document_Details");

            migrationBuilder.DropColumn(
                name: "fil02fil10uin",
                table: "fil02Document_Details");

            migrationBuilder.RenameColumn(
                name: "fil02description",
                table: "fil02Document_Details",
                newName: "fil02doctype");

            migrationBuilder.AddColumn<string>(
                name: "fil03category",
                table: "fil03attach_documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
