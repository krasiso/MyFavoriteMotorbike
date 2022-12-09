using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFavoriteMotorbike.Infrastructure.Migrations
{
    public partial class GoldenClientAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoldenClientId",
                table: "Motorbikes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GoldenClient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoldenClient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoldenClient_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81693837-9353-4dac-a5f2-4eade35a30f9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40fc097d-438d-4150-b881-0ae16146b3b7", "AQAAAAEAACcQAAAAECn5Zcl+dyDz+T9UGmKMCwWKgSE0W5q+qD6nEwQB8ZYVH5kW5AkJOTBzg1a3uYwEaQ==", "fa506298-4599-4447-b594-c866c6f8158c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8700b0e1-1cc6-4e31-81d8-0dc734f1d679",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5083333-0ea7-4068-9021-a74064d625c0", "AQAAAAEAACcQAAAAEOBTVtqs7LALwuYRnsKEzSp3adaQwI2WzjcfbIA1YRrj2uwQihRYRCaSfs1prf6vKw==", "e40f0f07-7d2b-4d2e-8e01-ca1f4d284bcd" });

            migrationBuilder.CreateIndex(
                name: "IX_Motorbikes_GoldenClientId",
                table: "Motorbikes",
                column: "GoldenClientId");

            migrationBuilder.CreateIndex(
                name: "IX_GoldenClient_UserId",
                table: "GoldenClient",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorbikes_GoldenClient_GoldenClientId",
                table: "Motorbikes",
                column: "GoldenClientId",
                principalTable: "GoldenClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorbikes_GoldenClient_GoldenClientId",
                table: "Motorbikes");

            migrationBuilder.DropTable(
                name: "GoldenClient");

            migrationBuilder.DropIndex(
                name: "IX_Motorbikes_GoldenClientId",
                table: "Motorbikes");

            migrationBuilder.DropColumn(
                name: "GoldenClientId",
                table: "Motorbikes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81693837-9353-4dac-a5f2-4eade35a30f9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9727e49-02d4-4928-ae54-a09fc26a11be", "AQAAAAEAACcQAAAAEDob4bSIYVaL+9jm5luFgQAl1048+NSEkL6w5dE+tAZlIUjr6CEqvVQjPutozsYQDg==", "d9000631-663b-4864-b100-479ad86f7e80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8700b0e1-1cc6-4e31-81d8-0dc734f1d679",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1069939d-1d42-4173-aaf3-2bed9d6ef6dc", "AQAAAAEAACcQAAAAEHWG/gXXtbuZVkgspkFt3IzcAgKJw6hoLNk0/cM0m7FMXQvYqYfKHGKBpWMz4D0+rA==", "ca15bc86-5451-44ce-a507-2e041345829e" });
        }
    }
}
