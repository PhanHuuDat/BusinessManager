using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessManager.DataAccess.Migrations
{
    public partial class changeCoverFormTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverDescription",
                table: "CoverForm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverDescription",
                table: "CoverForm",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
