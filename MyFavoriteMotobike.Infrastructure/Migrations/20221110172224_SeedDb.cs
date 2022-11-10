using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFavoriteMotobike.Infrastructure.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountriesOfOrigin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesOfOrigin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfStrokes = table.Column<int>(type: "int", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    CoolingType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CountryOfOriginId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_CountriesOfOrigin_CountryOfOriginId",
                        column: x => x.CountryOfOriginId,
                        principalTable: "CountriesOfOrigin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Motorbikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CubicCentimeters = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorbikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motorbikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Motorbikes_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motorbikes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motorbikes_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id");
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "81693837-9353-4dac-a5f2-4eade35a30f9", 0, "27b38051-36a8-4a52-a62b-e142776b37ea", "User", "administrator@mail.com", false, false, null, "administrator@mail.com", "administrator@mail.com", "AQAAAAEAACcQAAAAEH0hJB1lI0Y1UXJwR1o9jc1HlMW6+snB44arY/9D4VO3rNT5Fmdh4w+dpq/fIVhfQw==", null, false, "31aa8050-645d-44e0-a2c7-ba8c17e3b872", false, "administrator@mail.com" },
                    { "8700b0e1-1cc6-4e31-81d8-0dc734f1d679", 0, "af2f4339-47f2-46a7-a7d2-03e2025ae8d1", "User", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEKNqsOgtVrVX+2KCcC5lK0kYm9meI2G+4gxcroLqG6XS1FoLYPZmWbYMFXv/aXiMog==", null, false, "bbb1a6e9-0f3a-472a-9641-5b86f0a03af9", false, "guest@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CountryOfOriginId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Kawasaki" },
                    { 2, null, "Honda" },
                    { 3, null, "Yamaha" },
                    { 4, null, "Suzuki" },
                    { 5, null, "KTM" },
                    { 6, null, "Beta" },
                    { 7, null, "BMW" },
                    { 8, null, "Triumph" },
                    { 9, null, "Husaberg" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Motocross" },
                    { 2, "Dirt Bike" },
                    { 3, "Sport Bike" },
                    { 4, "Touring" },
                    { 5, "Custom" },
                    { 6, "Street Fighter" },
                    { 7, "Dual Sport" }
                });

            migrationBuilder.InsertData(
                table: "CountriesOfOrigin",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Japan" },
                    { 2, "Austria" },
                    { 3, "Italy" },
                    { 4, "Germany" },
                    { 5, "Great Britain" },
                    { 6, "Sweden" }
                });

            migrationBuilder.InsertData(
                table: "Administrator",
                columns: new[] { "UserId", "Id", "PhoneNumber" },
                values: new object[] { "81693837-9353-4dac-a5f2-4eade35a30f9", 1, "+359877777777" });

            migrationBuilder.InsertData(
                table: "Motorbikes",
                columns: new[] { "Id", "BrandId", "CategoryId", "CubicCentimeters", "Description", "EngineId", "ImageUrl", "Model", "PricePerDay", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, 250.00m, "This bike is for racing and amateur riding on a motocross track!", null, "https://content2.kawasaki.com/ContentStorage/KMC/ProductTrimGroup/56/1c0de86b-e024-4e09-8ba6-bd08b77344e5.jpg?w=750", "KX", 100.00m, null },
                    { 2, 2, 2, 450.00m, "This bike is for riding through mountains and off-road terrain!", null, "https://www.motofichas.com/images/cache/honda-crf450x-2011-739-a.jpg", "CRF", 100.00m, null },
                    { 3, 4, 3, 1300.00m, "This bike is for riding on the road and it's one of the fastest bikes ever!", null, "https://dizzyriders.bg/uploads/thumbs/gallery/2021-02/fe6c02c5a7fe382814b184f1c9e0bb62-620x427.jpg", "Hayabusa", 200.00m, null },
                    { 4, 7, 4, 1250.00m, "This bike is for long and comfortable riding on the road!", null, "https://dizzyriders.bg/uploads/thumbs/gallery/2021-02/fe6c02c5a7fe382814b184f1c9e0bb62-620x427.jpg", "R1250RT", 200.00m, null },
                    { 5, 8, 5, 900.00m, "This bike is for easy riding on the road!", null, "https://imgd.aeplcdn.com/1280x720/bw/models/triumph-street-twin-2021-standard20210401131021.jpg?q=80", "Street Twin", 100.00m, null },
                    { 6, 3, 6, 155.00m, "This bike is for riding on the road mostly in the city!", null, "https://www.indiacarnews.com/wp-content/uploads/2019/03/Yamaha-MT-15-International.jpg", "MT-15", 100.00m, null },
                    { 7, 5, 7, 990.00m, "This adventure is for almost any terreain!", null, "https://mcn-images.bauersecure.com/wp-images/19502/951x634/990_adventure_dakar.jpg?mode=max&quality=90&scale=down", "Adventure", 100.00m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CountryOfOriginId",
                table: "Brands",
                column: "CountryOfOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorbikes_BrandId",
                table: "Motorbikes",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorbikes_CategoryId",
                table: "Motorbikes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorbikes_EngineId",
                table: "Motorbikes",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorbikes_UserId",
                table: "Motorbikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersMotorbikes_MotorbikeId",
                table: "UsersMotorbikes",
                column: "MotorbikeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "UsersMotorbikes");

            migrationBuilder.DropTable(
                name: "Motorbikes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "CountriesOfOrigin");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8700b0e1-1cc6-4e31-81d8-0dc734f1d679");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81693837-9353-4dac-a5f2-4eade35a30f9");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
