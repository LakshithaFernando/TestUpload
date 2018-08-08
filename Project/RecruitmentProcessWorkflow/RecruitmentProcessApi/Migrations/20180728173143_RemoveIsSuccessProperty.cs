using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentProcessApi.Migrations
{
    public partial class RemoveIsSuccessProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSuccess",
                table: "workFlowSteps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSuccess",
                table: "workFlowSteps",
                nullable: false,
                defaultValue: false);
        }
    }
}
