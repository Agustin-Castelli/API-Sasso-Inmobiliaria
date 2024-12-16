using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SassoInmobiliariaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AttributeIsActiveAddedToDevPropEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DelevopName",
                table: "DevelopmentProps",
                newName: "DevelopName");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "DevelopmentProps",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "DevelopmentProps");

            migrationBuilder.RenameColumn(
                name: "DevelopName",
                table: "DevelopmentProps",
                newName: "DelevopName");
        }
    }
}
