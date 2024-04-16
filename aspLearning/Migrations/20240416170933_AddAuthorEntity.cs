using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspLearning.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                schema: "catalog",
                table: "MyCourse",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "catalog",
                table: "MyCourse",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyCourse_AuthorId",
                schema: "catalog",
                table: "MyCourse",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyCourse_Author_AuthorId",
                schema: "catalog",
                table: "MyCourse",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyCourse_Author_AuthorId",
                schema: "catalog",
                table: "MyCourse");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropIndex(
                name: "IX_MyCourse_AuthorId",
                schema: "catalog",
                table: "MyCourse");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                schema: "catalog",
                table: "MyCourse");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "catalog",
                table: "MyCourse");
        }
    }
}
