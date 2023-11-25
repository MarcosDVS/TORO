using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TORO.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Kilo",
                table: "FacturaDetalles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioKilo",
                table: "FacturaDetalles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kilo",
                table: "FacturaDetalles");

            migrationBuilder.DropColumn(
                name: "PrecioKilo",
                table: "FacturaDetalles");
        }
    }
}
