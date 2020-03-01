using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_project.Migrations
{
    public partial class createDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobGrades",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LowestSal = table.Column<decimal>(nullable: false),
                    HighestSal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    MinSalary = table.Column<decimal>(nullable: false),
                    MaxSalary = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 2, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: true),
                    RegionsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Regions_RegionsId",
                        column: x => x.RegionsId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(maxLength: 25, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 12, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    StateProvince = table.Column<string>(maxLength: 12, nullable: true),
                    CountriesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    ManagersId = table.Column<int>(nullable: false),
                    LocationsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobHistories",
                columns: table => new
                {
                    StartDate = table.Column<DateTime>(nullable: false),
                    EmployeesId = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    DepartmentsId = table.Column<int>(nullable: true),
                    JobId = table.Column<string>(maxLength: 10, nullable: true),
                    JobsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobHistories", x => new { x.EmployeesId, x.StartDate });
                    table.ForeignKey(
                        name: "FK_JobHistories_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobHistories_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 20, nullable: true),
                    LastName = table.Column<string>(maxLength: 25, nullable: true),
                    Email = table.Column<string>(maxLength: 25, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    HireDate = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    CommissionPct = table.Column<decimal>(nullable: false),
                    ManagerId = table.Column<int>(nullable: false),
                    DepartmentsId = table.Column<int>(nullable: true),
                    JobsId = table.Column<string>(nullable: true),
                    JobHistoriesEmployeesId = table.Column<int>(nullable: true),
                    JobHistoriesStartDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_JobHistories_JobHistoriesEmployeesId_JobHistoriesStartDate",
                        columns: x => new { x.JobHistoriesEmployeesId, x.JobHistoriesStartDate },
                        principalTable: "JobHistories",
                        principalColumns: new[] { "EmployeesId", "StartDate" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_RegionsId",
                table: "Countries",
                column: "RegionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LocationsId",
                table: "Departments",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentsId",
                table: "Employees",
                column: "DepartmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobsId",
                table: "Employees",
                column: "JobsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobHistoriesEmployeesId_JobHistoriesStartDate",
                table: "Employees",
                columns: new[] { "JobHistoriesEmployeesId", "JobHistoriesStartDate" });

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_DepartmentsId",
                table: "JobHistories",
                column: "DepartmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_JobsId",
                table: "JobHistories",
                column: "JobsId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CountriesId",
                table: "Locations",
                column: "CountriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "JobGrades");

            migrationBuilder.DropTable(
                name: "JobHistories");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
