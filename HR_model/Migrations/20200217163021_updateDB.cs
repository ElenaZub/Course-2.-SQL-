using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_model.Migrations
{
    public partial class updateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobHistories_Employees_EmployeesId",
                table: "jobHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jobHistories",
                table: "jobHistories");

            migrationBuilder.DropIndex(
                name: "IX_jobHistories_EmployeesId",
                table: "jobHistories");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "jobHistories");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "jobHistories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "JobHistoryEmployeeId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobHistories",
                table: "jobHistories",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobHistoryEmployeeId",
                table: "Employees",
                column: "JobHistoryEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_jobHistories_JobHistoryEmployeeId",
                table: "Employees",
                column: "JobHistoryEmployeeId",
                principalTable: "jobHistories",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_jobHistories_JobHistoryEmployeeId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jobHistories",
                table: "jobHistories");

            migrationBuilder.DropIndex(
                name: "IX_Employees_JobHistoryEmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "jobHistories");

            migrationBuilder.DropColumn(
                name: "JobHistoryEmployeeId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "jobHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobHistories",
                table: "jobHistories",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_jobHistories_EmployeesId",
                table: "jobHistories",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_jobHistories_Employees_EmployeesId",
                table: "jobHistories",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
