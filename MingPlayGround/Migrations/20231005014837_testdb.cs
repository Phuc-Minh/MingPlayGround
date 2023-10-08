using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MingPlayGround.Migrations
{
    /// <inheritdoc />
    public partial class testdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MuscleGroup_Exercice_Exercices_ExerciceId",
                table: "MuscleGroup_Exercice");

            migrationBuilder.DropForeignKey(
                name: "FK_MuscleGroup_Exercice_MuscleGroups_MuscleGroupId",
                table: "MuscleGroup_Exercice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MuscleGroup_Exercice",
                table: "MuscleGroup_Exercice");

            migrationBuilder.RenameTable(
                name: "MuscleGroup_Exercice",
                newName: "MuscleGroups_Exercices");

            migrationBuilder.RenameIndex(
                name: "IX_MuscleGroup_Exercice_ExerciceId",
                table: "MuscleGroups_Exercices",
                newName: "IX_MuscleGroups_Exercices_ExerciceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MuscleGroups_Exercices",
                table: "MuscleGroups_Exercices",
                columns: new[] { "MuscleGroupId", "ExerciceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleGroups_Exercices_Exercices_ExerciceId",
                table: "MuscleGroups_Exercices",
                column: "ExerciceId",
                principalTable: "Exercices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleGroups_Exercices_MuscleGroups_MuscleGroupId",
                table: "MuscleGroups_Exercices",
                column: "MuscleGroupId",
                principalTable: "MuscleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MuscleGroups_Exercices_Exercices_ExerciceId",
                table: "MuscleGroups_Exercices");

            migrationBuilder.DropForeignKey(
                name: "FK_MuscleGroups_Exercices_MuscleGroups_MuscleGroupId",
                table: "MuscleGroups_Exercices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MuscleGroups_Exercices",
                table: "MuscleGroups_Exercices");

            migrationBuilder.RenameTable(
                name: "MuscleGroups_Exercices",
                newName: "MuscleGroup_Exercice");

            migrationBuilder.RenameIndex(
                name: "IX_MuscleGroups_Exercices_ExerciceId",
                table: "MuscleGroup_Exercice",
                newName: "IX_MuscleGroup_Exercice_ExerciceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MuscleGroup_Exercice",
                table: "MuscleGroup_Exercice",
                columns: new[] { "MuscleGroupId", "ExerciceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleGroup_Exercice_Exercices_ExerciceId",
                table: "MuscleGroup_Exercice",
                column: "ExerciceId",
                principalTable: "Exercices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleGroup_Exercice_MuscleGroups_MuscleGroupId",
                table: "MuscleGroup_Exercice",
                column: "MuscleGroupId",
                principalTable: "MuscleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
