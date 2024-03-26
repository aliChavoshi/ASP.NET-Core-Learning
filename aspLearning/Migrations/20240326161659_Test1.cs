using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspLearning.Migrations
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MyCourse_Name",
                schema: "catalog",
                table: "MyCourse");

            migrationBuilder.CreateIndex(
                name: "IX_MyCourse_Name",
                schema: "catalog",
                table: "MyCourse",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MyCourse_Name",
                schema: "catalog",
                table: "MyCourse");

            migrationBuilder.CreateIndex(
                name: "IX_MyCourse_Name",
                schema: "catalog",
                table: "MyCourse",
                column: "Name");
        }
    }
}
