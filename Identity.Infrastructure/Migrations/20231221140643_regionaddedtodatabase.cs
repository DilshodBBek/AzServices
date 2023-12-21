using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class regionaddedtodatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DistrictEntity_Districtid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RegionEntity_Regionid",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegionEntity",
                table: "RegionEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DistrictEntity",
                table: "DistrictEntity");

            migrationBuilder.RenameTable(
                name: "RegionEntity",
                newName: "Regions");

            migrationBuilder.RenameTable(
                name: "DistrictEntity",
                newName: "Districts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "RegionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Districts_Districtid",
                table: "AspNetUsers",
                column: "Districtid",
                principalTable: "Districts",
                principalColumn: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Regions_Regionid",
                table: "AspNetUsers",
                column: "Regionid",
                principalTable: "Regions",
                principalColumn: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Districts_Districtid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Regions_Regionid",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "RegionEntity");

            migrationBuilder.RenameTable(
                name: "Districts",
                newName: "DistrictEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegionEntity",
                table: "RegionEntity",
                column: "RegionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DistrictEntity",
                table: "DistrictEntity",
                column: "DistrictId");

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
    }
}
