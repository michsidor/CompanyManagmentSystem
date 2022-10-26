using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    public partial class DeletingMounthsOfWorkSaveFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MounthsInWork",
                table: "EmployeeExtensionDataSet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MounthsInWork",
                table: "EmployeeExtensionDataSet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
