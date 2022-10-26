using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeBasicDataSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheRoleOff = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBasicDataSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsDataSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costs = table.Column<int>(type: "int", nullable: false),
                    PotentialProfit = table.Column<int>(type: "int", nullable: false),
                    Complited = table.Column<bool>(type: "bit", nullable: false),
                    ManagerOfProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsDataSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsDataSet_EmployeeBasicDataSet_ManagerOfProjectId",
                        column: x => x.ManagerOfProjectId,
                        principalTable: "EmployeeBasicDataSet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeExtensionDataSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeId = table.Column<int>(type: "int", nullable: true),
                    ActuallProjectId = table.Column<int>(type: "int", nullable: true),
                    PaymentGross = table.Column<int>(type: "int", nullable: false),
                    PaymentNet = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MounthsInWork = table.Column<int>(type: "int", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    DaysOfVacation = table.Column<int>(type: "int", nullable: false),
                    DaysOfVacationLeft = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeExtensionDataSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeExtensionDataSet_EmployeeBasicDataSet_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "EmployeeBasicDataSet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeExtensionDataSet_ProjectsDataSet_ActuallProjectId",
                        column: x => x.ActuallProjectId,
                        principalTable: "ProjectsDataSet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExtensionDataSet_ActuallProjectId",
                table: "EmployeeExtensionDataSet",
                column: "ActuallProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExtensionDataSet_EmployeId",
                table: "EmployeeExtensionDataSet",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsDataSet_ManagerOfProjectId",
                table: "ProjectsDataSet",
                column: "ManagerOfProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeExtensionDataSet");

            migrationBuilder.DropTable(
                name: "ProjectsDataSet");

            migrationBuilder.DropTable(
                name: "EmployeeBasicDataSet");
        }
    }
}
