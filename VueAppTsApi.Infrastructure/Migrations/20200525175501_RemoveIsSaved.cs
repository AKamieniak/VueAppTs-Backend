using Microsoft.EntityFrameworkCore.Migrations;

namespace VueAppTsApi.Infrastructure.Migrations
{
    public partial class RemoveIsSaved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSaved",
                schema: "app",
                table: "Images");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSaved",
                schema: "app",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
