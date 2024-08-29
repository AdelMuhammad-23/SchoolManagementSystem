using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "subjects",
                newName: "SubjectNameEn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "students",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "DName",
                table: "departments",
                newName: "DNameEn");

            migrationBuilder.AddColumn<string>(
                name: "SubjectNameAR",
                table: "subjects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DNameAr",
                table: "departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectNameAR",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "students");

            migrationBuilder.DropColumn(
                name: "DNameAr",
                table: "departments");

            migrationBuilder.RenameColumn(
                name: "SubjectNameEn",
                table: "subjects",
                newName: "SubjectName");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DNameEn",
                table: "departments",
                newName: "DName");
        }
    }
}
