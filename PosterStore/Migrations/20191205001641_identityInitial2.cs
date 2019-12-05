using Microsoft.EntityFrameworkCore.Migrations;

namespace PosterStore.Migrations
{
    public partial class identityInitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ages",
                table: "AspNetUsers",
                newName: "Age");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "AspNetUsers",
                newName: "Ages");
        }
    }
}
