using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspLearning.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MyCourse_Name",
                schema: "catalog",
                table: "MyCourse");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "catalog",
                table: "MyCourse",
                newName: "MyName");

            migrationBuilder.AlterColumn<string>(
                name: "MyName",
                schema: "catalog",
                table: "MyCourse",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyName",
                schema: "catalog",
                table: "MyCourse",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "catalog",
                table: "MyCourse",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.CreateIndex(
                name: "IX_MyCourse_Name",
                schema: "catalog",
                table: "MyCourse",
                column: "Name",
                unique: true);
        }
    }
}
