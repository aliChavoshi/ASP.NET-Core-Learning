using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspLearning.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "MyCourse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyCourse",
                table: "MyCourse",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyCourse",
                table: "MyCourse");

            migrationBuilder.RenameTable(
                name: "MyCourse",
                newName: "Courses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");
        }
    }
}
