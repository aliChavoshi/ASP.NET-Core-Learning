using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspLearning.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "catalog",
                table: "MyCourse",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_MyCourse_Name",
                schema: "catalog",
                table: "MyCourse",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MyCourse_Name",
                schema: "catalog",
                table: "MyCourse");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "catalog",
                table: "MyCourse",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
