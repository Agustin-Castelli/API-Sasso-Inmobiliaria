using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SassoInmobiliariaAPI.Migrations
{
    /// <inheritdoc />
    public partial class newColumnStateOfDevelop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateOfDevelop",
                table: "Propertys",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateOfDevelop",
                table: "Propertys");
        }
    }
}
