using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ServiceCatalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Descryption = table.Column<string>(type: "text", nullable: false),
                    OpenTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    CloseTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    BaseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileContents_Base_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    PlaystationAreaId = table.Column<int>(type: "integer", nullable: true),
                    StadiumId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitBase_Base_PlaystationAreaId",
                        column: x => x.PlaystationAreaId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitBase_Base_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingPlaystations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BroneTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    BronePhoneNumber = table.Column<string>(type: "text", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingPlaystations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingPlaystations_UnitBase_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "UnitBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BroneStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookingStatusId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatuseId = table.Column<List<int>>(type: "integer[]", nullable: false),
                    UnitBaseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BroneStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BroneStatus_UnitBase_UnitBaseId",
                        column: x => x.UnitBaseId,
                        principalTable: "UnitBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingPlaystations_ServiceId",
                table: "BookingPlaystations",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BroneStatus_UnitBaseId",
                table: "BroneStatus",
                column: "UnitBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_FileContents_BaseId",
                table: "FileContents",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitBase_PlaystationAreaId",
                table: "UnitBase",
                column: "PlaystationAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitBase_StadiumId",
                table: "UnitBase",
                column: "StadiumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingPlaystations");

            migrationBuilder.DropTable(
                name: "BroneStatus");

            migrationBuilder.DropTable(
                name: "FileContents");

            migrationBuilder.DropTable(
                name: "UnitBase");

            migrationBuilder.DropTable(
                name: "Base");
        }
    }
}
