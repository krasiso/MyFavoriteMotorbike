using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFavoriteMotorbike.Infrastructure.Migrations
{
    public partial class ColumnIsActiveAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "UsersMotorbikes");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Motorbikes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RenterId",
                table: "Motorbikes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserMotorbikeId",
                table: "Motorbikes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserMotorbikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MotorbikeId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMotorbikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMotorbikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMotorbikes_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMotorbikes_Motorbikes_MotorbikeId",
                        column: x => x.MotorbikeId,
                        principalTable: "Motorbikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81693837-9353-4dac-a5f2-4eade35a30f9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "672d0b3e-8028-43e2-815f-f2a888b9a4a1", "AQAAAAEAACcQAAAAEETFYq+JKzrN4UiqSvlwUeEYQ0RmQAezqSN85ZOi862nNFrf3EBtZ3vgAhaMF9Dc/g==", "d9b22dbe-7011-4629-bbca-4ba30c3e9dd9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8700b0e1-1cc6-4e31-81d8-0dc734f1d679",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e40223c-3be7-455c-824b-14c7cc645c19", "AQAAAAEAACcQAAAAEILlX/BZ8AYZrtsg16djO+QG6wYV/DxhUbb5BUQh9qqkDmGDxRPz59PQLBB1jlnCXg==", "6fb4c86a-1ff9-47cc-911d-2b567bd271ec" });

            migrationBuilder.CreateIndex(
                name: "IX_Motorbikes_RenterId",
                table: "Motorbikes",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorbikes_UserMotorbikeId",
                table: "Motorbikes",
                column: "UserMotorbikeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMotorbikes_BrandId",
                table: "UserMotorbikes",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMotorbikes_MotorbikeId",
                table: "UserMotorbikes",
                column: "MotorbikeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMotorbikes_UserId",
                table: "UserMotorbikes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorbikes_AspNetUsers_RenterId",
                table: "Motorbikes",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorbikes_UserMotorbikes_UserMotorbikeId",
                table: "Motorbikes",
                column: "UserMotorbikeId",
                principalTable: "UserMotorbikes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorbikes_AspNetUsers_RenterId",
                table: "Motorbikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorbikes_UserMotorbikes_UserMotorbikeId",
                table: "Motorbikes");

            migrationBuilder.DropTable(
                name: "UserMotorbikes");

            migrationBuilder.DropIndex(
                name: "IX_Motorbikes_RenterId",
                table: "Motorbikes");

            migrationBuilder.DropIndex(
                name: "IX_Motorbikes_UserMotorbikeId",
                table: "Motorbikes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Motorbikes");

            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "Motorbikes");

            migrationBuilder.DropColumn(
                name: "UserMotorbikeId",
                table: "Motorbikes");

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Administrator_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersMotorbikes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MotorbikeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersMotorbikes", x => new { x.UserId, x.MotorbikeId });
                    table.ForeignKey(
                        name: "FK_UsersMotorbikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersMotorbikes_Motorbikes_MotorbikeId",
                        column: x => x.MotorbikeId,
                        principalTable: "Motorbikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Administrator",
                columns: new[] { "UserId", "Id", "PhoneNumber" },
                values: new object[] { "81693837-9353-4dac-a5f2-4eade35a30f9", 1, "+359877777777" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81693837-9353-4dac-a5f2-4eade35a30f9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d914c741-276b-4bb2-be3b-f1b92451f72b", "AQAAAAEAACcQAAAAEDjQYPrt735LfOrH1NA8MTQyBaPqvbc4Ftfe/Gz9MyUOhp22k5S9/NySv3Ns50pjzA==", "e88b6786-b729-463d-8982-a7ac985302d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8700b0e1-1cc6-4e31-81d8-0dc734f1d679",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96599989-7857-414d-be1e-3550ec078c70", "AQAAAAEAACcQAAAAEONtA0xQ5ShPSgmHqWDlwE17l9d+B9HmMe1nVoSELmURzxk9IV9qfa0eY3A6UffmkQ==", "1684d2c8-a526-4656-8d48-f2921ee31909" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersMotorbikes_MotorbikeId",
                table: "UsersMotorbikes",
                column: "MotorbikeId");
        }
    }
}
