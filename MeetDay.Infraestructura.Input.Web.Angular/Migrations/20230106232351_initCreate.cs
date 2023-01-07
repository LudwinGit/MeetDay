using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MeetDay.Infraestructura.Input.Web.Angular.Migrations
{
    public partial class initCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "catalogDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    State = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", maxLength: 1000, nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "document_management",
                columns: table => new
                {
                    CatalogDocumentId = table.Column<int>(type: "integer", nullable: false),
                    ManagementId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document_management", x => new { x.CatalogDocumentId, x.ManagementId });
                });

            migrationBuilder.CreateTable(
                name: "managements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    State = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    Observation = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_managements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Role = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "catalogDocuments");

            migrationBuilder.DropTable(
                name: "document_management");

            migrationBuilder.DropTable(
                name: "managements");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
