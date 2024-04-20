using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entrega2.PGPIC.API.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResearchProjectId",
                table: "SpecializedResources",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecializedResources_ResearchProjectId",
                table: "SpecializedResources",
                column: "ResearchProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecializedResources_ResearchProjects_ResearchProjectId",
                table: "SpecializedResources",
                column: "ResearchProjectId",
                principalTable: "ResearchProjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecializedResources_ResearchProjects_ResearchProjectId",
                table: "SpecializedResources");

            migrationBuilder.DropIndex(
                name: "IX_SpecializedResources_ResearchProjectId",
                table: "SpecializedResources");

            migrationBuilder.DropColumn(
                name: "ResearchProjectId",
                table: "SpecializedResources");
        }
    }
}
