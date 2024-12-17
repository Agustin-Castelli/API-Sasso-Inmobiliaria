using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SassoInmobiliariaAPI.Migrations
{
    /// <inheritdoc />
    public partial class newColumnDevProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateOfDevelop",
                table: "DevelopmentProps",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateOfDevelop",
                table: "DevelopmentProps");
        }
    }
}
