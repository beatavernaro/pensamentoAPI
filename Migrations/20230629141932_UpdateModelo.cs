using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pensamentoAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Pensamentos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Pensamentos");
        }
    }
}
