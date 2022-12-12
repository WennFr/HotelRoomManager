using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelRoomManager.Migrations
{
    /// <inheritdoc />
    public partial class Changestoclasspropertiesandrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_ExtraBed_ExtraBedId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_ExtraBedId",
                table: "Room");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Room_ExtraBedId",
                table: "Room",
                column: "ExtraBedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_ExtraBed_ExtraBedId",
                table: "Room",
                column: "ExtraBedId",
                principalTable: "ExtraBed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
