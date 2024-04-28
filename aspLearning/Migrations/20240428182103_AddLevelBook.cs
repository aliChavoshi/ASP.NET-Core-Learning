using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspLearning.Migrations
{
    /// <inheritdoc />
    public partial class AddLevelBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Books");
        }
    }
}
