using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Optional.Migrations
{
    public partial class IdEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdEntry",
                table: "dates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEntry",
                table: "dates");
        }
    }
}
