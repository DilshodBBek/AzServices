using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class regionadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Districtid",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Regionid",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DistrictEntity",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DistrictNameUz = table.Column<string>(type: "text", nullable: true),
                    DistrictNameRu = table.Column<string>(type: "text", nullable: true),
                    DistrictNameEn = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictEntity", x => x.DistrictId);
                });

            migrationBuilder.CreateTable(
                name: "RegionEntity",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegionNameUz = table.Column<string>(type: "text", nullable: true),
                    RegionNameRu = table.Column<string>(type: "text", nullable: true),
                    RegionNameEn = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionEntity", x => x.RegionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Districtid",
                table: "AspNetUsers",
                column: "Districtid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Regionid",
                table: "AspNetUsers",
                column: "Regionid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DistrictEntity_Districtid",
                table: "AspNetUsers",
                column: "Districtid",
                principalTable: "DistrictEntity",
                principalColumn: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RegionEntity_Regionid",
                table: "AspNetUsers",
                column: "Regionid",
                principalTable: "RegionEntity",
                principalColumn: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DistrictEntity_Districtid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RegionEntity_Regionid",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DistrictEntity");

            migrationBuilder.DropTable(
                name: "RegionEntity");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Districtid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Regionid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Districtid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Regionid",
                table: "AspNetUsers");
        }
    }
}
