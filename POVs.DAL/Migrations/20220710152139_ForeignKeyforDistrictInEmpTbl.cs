using Microsoft.EntityFrameworkCore.Migrations;

namespace POVs.DAL.Migrations
{
    public partial class ForeignKeyforDistrictInEmpTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DistrictId",
                table: "Employee",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_District_DistrictId",
                table: "Employee",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_District_DistrictId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DistrictId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Employee");
        }
    }
}
