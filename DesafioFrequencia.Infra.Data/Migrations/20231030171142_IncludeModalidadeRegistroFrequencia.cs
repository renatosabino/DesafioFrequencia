using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioFrequencia.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class IncludeModalidadeRegistroFrequencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Modalidade",
                table: "RegistroFrequencias",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modalidade",
                table: "RegistroFrequencias");
        }
    }
}
