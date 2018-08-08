using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentProcessApi.Migrations
{
    public partial class changeTheDataTypeOfIsActiveProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "workFlowSteps",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "workFlowSteps",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
