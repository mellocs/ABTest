using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceExperiments_Devices_DeviceId",
                table: "DeviceExperiments");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceExperiments_Experiments_ExperimentId",
                table: "DeviceExperiments");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "DeviceExperiments");

            migrationBuilder.AddColumn<int>(
                name: "OptionId",
                table: "DeviceExperiments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Probability = table.Column<float>(type: "real", nullable: false),
                    ExperimentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Experiments_ExperimentId",
                        column: x => x.ExperimentId,
                        principalTable: "Experiments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceExperiments_OptionId",
                table: "DeviceExperiments",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ExperimentId",
                table: "Options",
                column: "ExperimentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceExperiments_Devices_DeviceId",
                table: "DeviceExperiments",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceExperiments_Experiments_ExperimentId",
                table: "DeviceExperiments",
                column: "ExperimentId",
                principalTable: "Experiments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceExperiments_Options_OptionId",
                table: "DeviceExperiments",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceExperiments_Devices_DeviceId",
                table: "DeviceExperiments");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceExperiments_Experiments_ExperimentId",
                table: "DeviceExperiments");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceExperiments_Options_OptionId",
                table: "DeviceExperiments");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropIndex(
                name: "IX_DeviceExperiments_OptionId",
                table: "DeviceExperiments");

            migrationBuilder.DropColumn(
                name: "OptionId",
                table: "DeviceExperiments");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "DeviceExperiments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceExperiments_Devices_DeviceId",
                table: "DeviceExperiments",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceExperiments_Experiments_ExperimentId",
                table: "DeviceExperiments",
                column: "ExperimentId",
                principalTable: "Experiments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
