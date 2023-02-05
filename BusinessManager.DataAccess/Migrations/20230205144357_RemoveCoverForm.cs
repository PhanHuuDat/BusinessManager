using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessManager.DataAccess.Migrations
{
    public partial class RemoveCoverForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_CoverForm_CoverFormId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "CoverForm");

            migrationBuilder.DropIndex(
                name: "IX_Book_CoverFormId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "CoverFormId",
                table: "Book");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoverFormId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CoverForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverForm", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CoverFormId",
                table: "Book",
                column: "CoverFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_CoverForm_CoverFormId",
                table: "Book",
                column: "CoverFormId",
                principalTable: "CoverForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
