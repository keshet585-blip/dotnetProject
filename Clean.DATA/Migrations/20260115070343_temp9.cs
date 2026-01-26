using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.DATA.Migrations
{
    /// <inheritdoc />
    public partial class temp9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeRoleInProject",
                table: "Assignments",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(90)",
                oldMaxLength: 90);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeRoleInProject",
                table: "Assignments",
                type: "nvarchar(90)",
                maxLength: 90,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);
        }
    }
}
