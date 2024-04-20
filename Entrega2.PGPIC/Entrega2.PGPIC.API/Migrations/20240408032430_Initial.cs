using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entrega2.PGPIC.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Researchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Afiliation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResearchProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecializedResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequiredQuantity = table.Column<int>(type: "int", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstimatedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializedResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publications_ResearchProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ResearchProjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResearchActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchActivities_ResearchProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ResearchProjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResearchProjectResearcher",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    ResearchersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchProjectResearcher", x => new { x.ProjectsId, x.ResearchersId });
                    table.ForeignKey(
                        name: "FK_ResearchProjectResearcher_ResearchProjects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "ResearchProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResearchProjectResearcher_Researchers_ResearchersId",
                        column: x => x.ResearchersId,
                        principalTable: "Researchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchActivitySpecializedResource",
                columns: table => new
                {
                    ActivitiesId = table.Column<int>(type: "int", nullable: false),
                    ResourcesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchActivitySpecializedResource", x => new { x.ActivitiesId, x.ResourcesId });
                    table.ForeignKey(
                        name: "FK_ResearchActivitySpecializedResource_ResearchActivities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "ResearchActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResearchActivitySpecializedResource_SpecializedResources_ResourcesId",
                        column: x => x.ResourcesId,
                        principalTable: "SpecializedResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publications_ProjectId",
                table: "Publications",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchActivities_ProjectId",
                table: "ResearchActivities",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchActivitySpecializedResource_ResourcesId",
                table: "ResearchActivitySpecializedResource",
                column: "ResourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchProjectResearcher_ResearchersId",
                table: "ResearchProjectResearcher",
                column: "ResearchersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "ResearchActivitySpecializedResource");

            migrationBuilder.DropTable(
                name: "ResearchProjectResearcher");

            migrationBuilder.DropTable(
                name: "ResearchActivities");

            migrationBuilder.DropTable(
                name: "SpecializedResources");

            migrationBuilder.DropTable(
                name: "Researchers");

            migrationBuilder.DropTable(
                name: "ResearchProjects");
        }
    }
}
