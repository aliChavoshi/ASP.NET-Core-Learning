using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspLearning.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameTableSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.RenameTable(
                name: "MyCourse",
                newName: "MyCourse",
                newSchema: "catalog");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "MyCourse",
                schema: "catalog",
                newName: "MyCourse");
        }
    }
}
