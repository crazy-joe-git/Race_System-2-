using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Race_System_2_.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRegistrationCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Registration",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Registration");
        }
    }
}
