using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entrega2.PGPIC.API.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingFks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_ResearchProjects_ProjectId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_ResearchActivities_ResearchProjects_ProjectId",
                table: "ResearchActivities");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ResearchActivities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Publications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_ResearchProjects_ProjectId",
                table: "Publications",
                column: "ProjectId",
                principalTable: "ResearchProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchActivities_ResearchProjects_ProjectId",
                table: "ResearchActivities",
                column: "ProjectId",
                principalTable: "ResearchProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_ResearchProjects_ProjectId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_ResearchActivities_ResearchProjects_ProjectId",
                table: "ResearchActivities");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ResearchActivities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Publications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_ResearchProjects_ProjectId",
                table: "Publications",
                column: "ProjectId",
                principalTable: "ResearchProjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchActivities_ResearchProjects_ProjectId",
                table: "ResearchActivities",
                column: "ProjectId",
                principalTable: "ResearchProjects",
                principalColumn: "Id");
        }
    }
}
