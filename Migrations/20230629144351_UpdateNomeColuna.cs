using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pensamentoAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNomeColuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pensamento",
                table: "Pensamentos",
                newName: "Conteudo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Conteudo",
                table: "Pensamentos",
                newName: "Pensamento");
        }
    }
}
