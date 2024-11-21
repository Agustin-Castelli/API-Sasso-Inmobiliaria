using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SassoInmobiliariaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevelopmentProps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DelevopName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DevelopDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DevelopAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DevelopImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentProps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propertys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<float>(type: "real", nullable: false),
                    Baths = table.Column<int>(type: "int", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDistingued = table.Column<bool>(type: "bit", nullable: false),
                    IsUpToCredit = table.Column<bool>(type: "bit", nullable: false),
                    TypeOfProp = table.Column<int>(type: "int", nullable: true),
                    TypeOfOffer = table.Column<int>(type: "int", nullable: true),
                    DevelopmentPropId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propertys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propertys_DevelopmentProps_DevelopmentPropId",
                        column: x => x.DevelopmentPropId,
                        principalTable: "DevelopmentProps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Propertys_DevelopmentPropId",
                table: "Propertys",
                column: "DevelopmentPropId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Propertys");

            migrationBuilder.DropTable(
                name: "DevelopmentProps");
        }
    }
}
