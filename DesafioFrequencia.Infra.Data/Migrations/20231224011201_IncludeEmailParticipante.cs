using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioFrequencia.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class IncludeEmailParticipante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Participantes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Participantes");
        }
    }
}
