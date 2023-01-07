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
                name: "catalog_documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    state = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    date_create = table.Column<DateTime>(type: "timestamp without time zone", maxLength: 1000, nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalog_documents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "document_management",
                columns: table => new
                {
                    catalogdocumentid = table.Column<int>(type: "integer", nullable: false),
                    managementid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document_management", x => new { x.catalogdocumentid, x.managementid });
                });

            migrationBuilder.CreateTable(
                name: "managements",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    state = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    observation = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    date_create = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_managements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    role = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    state = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    date_created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    date_update = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "catalog_documents");

            migrationBuilder.DropTable(
                name: "document_management");

            migrationBuilder.DropTable(
                name: "managements");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
