using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS1_2024_25.API.Migrations
{
    /// <inheritdoc />
    public partial class initial22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTine",
                table: "GameSessions",
                newName: "StartTime");

            migrationBuilder.AddColumn<int>(
                name: "ActualPlayTime",
                table: "GameSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CurrentUserId",
                table: "Devices",
                column: "CurrentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Users_CurrentUserId",
                table: "Devices",
                column: "CurrentUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Users_CurrentUserId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_CurrentUserId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "ActualPlayTime",
                table: "GameSessions");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "GameSessions",
                newName: "StartTine");
        }
    }
}
