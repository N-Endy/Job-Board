using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeApplicationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Applicants_ApplicantId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Staffs_StaffId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_StaffId",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantFullName",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssignedStaffName",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Applicants_ApplicantId",
                table: "Applications",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Applicants_ApplicantId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicantFullName",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "AssignedStaffName",
                table: "Applications");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_StaffId",
                table: "Applications",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Applicants_ApplicantId",
                table: "Applications",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Staffs_StaffId",
                table: "Applications",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId");
        }
    }
}
