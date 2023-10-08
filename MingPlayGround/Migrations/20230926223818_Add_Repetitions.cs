using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MingPlayGround.Migrations
{
    /// <inheritdoc />
    public partial class Add_Repetitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DurationSecondes",
                table: "Exercices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Repetitions",
                table: "Exercices",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "Exercices");

            migrationBuilder.AlterColumn<int>(
                name: "DurationSecondes",
                table: "Exercices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
