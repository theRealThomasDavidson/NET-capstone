using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentProjectAttempt6.Migrations
{
    /// <inheritdoc />
    public partial class i2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "grade",
                table: "Students",
                newName: "Grade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "Students",
                newName: "grade");
        }
    }
}
