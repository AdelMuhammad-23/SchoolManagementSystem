using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_subjectsStudents",
                table: "subjectsStudents");

            migrationBuilder.DropIndex(
                name: "IX_subjectsStudents_SubID",
                table: "subjectsStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departmentSubjects",
                table: "departmentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_departmentSubjects_SubID",
                table: "departmentSubjects");

            migrationBuilder.DropColumn(
                name: "StudSubID",
                table: "subjectsStudents");

            migrationBuilder.DropColumn(
                name: "DeptSubID",
                table: "departmentSubjects");

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "InsManager",
                table: "departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_subjectsStudents",
                table: "subjectsStudents",
                columns: new[] { "SubID", "StudID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_departmentSubjects",
                table: "departmentSubjects",
                columns: new[] { "SubID", "DID" });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InsId);
                    table.ForeignKey(
                        name: "FK_Instructor_Instructor_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Instructor",
                        principalColumn: "InsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructor_departments_DID",
                        column: x => x.DID,
                        principalTable: "departments",
                        principalColumn: "DID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ins_Subject",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false),
                    SubID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ins_Subject", x => new { x.SubID, x.InsId });
                    table.ForeignKey(
                        name: "FK_Ins_Subject_Instructor_InsId",
                        column: x => x.InsId,
                        principalTable: "Instructor",
                        principalColumn: "InsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ins_Subject_subjects_SubID",
                        column: x => x.SubID,
                        principalTable: "subjects",
                        principalColumn: "SubID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departments_InsManager",
                table: "departments",
                column: "InsManager",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ins_Subject_InsId",
                table: "Ins_Subject",
                column: "InsId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_DID",
                table: "Instructor",
                column: "DID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_SupervisorId",
                table: "Instructor",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_Instructor_InsManager",
                table: "departments",
                column: "InsManager",
                principalTable: "Instructor",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_Instructor_InsManager",
                table: "departments");

            migrationBuilder.DropTable(
                name: "Ins_Subject");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subjectsStudents",
                table: "subjectsStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departmentSubjects",
                table: "departmentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_departments_InsManager",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "InsManager",
                table: "departments");

            migrationBuilder.AddColumn<int>(
                name: "StudSubID",
                table: "subjectsStudents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DeptSubID",
                table: "departmentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subjectsStudents",
                table: "subjectsStudents",
                column: "StudSubID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departmentSubjects",
                table: "departmentSubjects",
                column: "DeptSubID");

            migrationBuilder.CreateIndex(
                name: "IX_subjectsStudents_SubID",
                table: "subjectsStudents",
                column: "SubID");

            migrationBuilder.CreateIndex(
                name: "IX_departmentSubjects_SubID",
                table: "departmentSubjects",
                column: "SubID");
        }
    }
}
