using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Race_System_2_.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RankInCategory",
                table: "Result");

            migrationBuilder.RenameColumn(
                name: "RankOverall",
                table: "Result",
                newName: "Position");

            migrationBuilder.AlterColumn<string>(
                name: "FinishTime",
                table: "Result",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Result",
                newName: "RankOverall");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "FinishTime",
                table: "Result",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "RankInCategory",
                table: "Result",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
