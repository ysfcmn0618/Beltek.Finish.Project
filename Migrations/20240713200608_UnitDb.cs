using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beltek.Finish.Project.Migrations
{
    /// <inheritdoc />
    public partial class UnitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblClasses",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ClassQuota = table.Column<int>(type: "int", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClasses", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "tblStudents",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    StudentSurname = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    StudentNumber = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStudents", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_tblStudents_tblClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "tblClasses",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblStudents_ClassId",
                table: "tblStudents",
                column: "ClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblStudents");

            migrationBuilder.DropTable(
                name: "tblClasses");
        }
    }
}
