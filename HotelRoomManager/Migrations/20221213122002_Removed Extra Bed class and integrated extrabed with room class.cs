using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelRoomManager.Migrations
{
    /// <inheritdoc />
    public partial class RemovedExtraBedclassandintegratedextrabedwithroomclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_ExtraBed_ExtraBedId",
                table: "Room");

            migrationBuilder.DropTable(
                name: "ExtraBed");

            migrationBuilder.DropIndex(
                name: "IX_Room_ExtraBedId",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "ExtraBedId",
                table: "Room",
                newName: "ExtraBed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExtraBed",
                table: "Room",
                newName: "ExtraBedId");

            migrationBuilder.CreateTable(
                name: "ExtraBed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllowedAmountOfExtraBeds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraBed", x => x.Id);
                });

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
