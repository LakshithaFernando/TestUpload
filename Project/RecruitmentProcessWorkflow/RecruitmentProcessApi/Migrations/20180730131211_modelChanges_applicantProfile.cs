using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentProcessApi.Migrations
{
    public partial class modelChanges_applicantProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_applicantProfiles",
                table: "applicantProfiles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "applicantProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantNo",
                table: "applicantProfiles",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "applicantProfiles",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuccess",
                table: "applicantProfiles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "WorkFlowId",
                table: "applicantProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_applicantProfiles",
                table: "applicantProfiles",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_applicantProfiles",
                table: "applicantProfiles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "applicantProfiles");

            migrationBuilder.DropColumn(
                name: "IsSuccess",
                table: "applicantProfiles");

            migrationBuilder.DropColumn(
                name: "WorkFlowId",
                table: "applicantProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantNo",
                table: "applicantProfiles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "applicantProfiles",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_applicantProfiles",
                table: "applicantProfiles",
                column: "ApplicantNo");
        }
    }
}
