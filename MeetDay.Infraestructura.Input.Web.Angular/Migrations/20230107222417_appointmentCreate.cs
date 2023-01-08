using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MeetDay.Infraestructura.Input.Web.Angular.Migrations
{
    public partial class appointmentCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gestionid = table.Column<int>(type: "integer", nullable: false),
                    observation = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    state = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    date_created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    date_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "document",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    document64 = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    date_created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "document_appointment",
                columns: table => new
                {
                    document_id = table.Column<int>(type: "integer", nullable: false),
                    catalogdocument_id = table.Column<int>(type: "integer", nullable: false),
                    appointment_id = table.Column<int>(type: "integer", nullable: false),
                    date_created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document_appointment", x => new { x.document_id, x.catalogdocument_id, x.appointment_id });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "document");

            migrationBuilder.DropTable(
                name: "document_appointment");
        }
    }
}
