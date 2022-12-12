using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFavoriteMotorbike.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoldenClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoldenClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoldenClients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Variety = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CubicCentimeters = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PricePerDay = table.Column<decimal>(type: "money", precision: 18, scale: 2, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GoldenClientId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorbikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motorbikes_AspNetUsers_RenterId",
                        column: x => x.RenterId,
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
                        name: "FK_Motorbikes_GoldenClients_GoldenClientId",
                        column: x => x.GoldenClientId,
                        principalTable: "GoldenClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "81693837-9353-4dac-a5f2-4eade35a30f9", 0, "d4cf6195-dd79-4c57-92af-9feb9b38d5fc", "goldenclient@mail.com", false, false, null, "goldenclient@mail.com", "goldenclient@mail.com", "AQAAAAEAACcQAAAAEBocpm0fXLnZR/ghFI3zWBWds38+SWIoOMJaXS/0uESWcX8N9tgUVCsC6l+zY18WNA==", null, false, "aae1c1bd-a002-4bc2-809f-5645adecdf4e", false, "goldenclient@mail.com" },
                    { "8700b0e1-1cc6-4e31-81d8-0dc734f1d679", 0, "2f136dc9-d9d9-4cdb-8cb1-e4067d57fb47", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEEACm/mpWGi9kvpPUpY/gR5GSSfLsQUFOPdG4G+ExVoAaZZvX5EyT8bNzOJzr2MrbQ==", null, false, "e07168a1-85e2-4dd8-9f94-5b77a53253a0", false, "guest@mail.com" }
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
                    { 9, null, "Husaberg" },
                    { 10, null, "Harley Davidson" },
                    { 11, null, "Indian" },
                    { 12, null, "Royal Enfield" },
                    { 13, null, "Husqvarna" },
                    { 14, null, "Ural" },
                    { 15, null, "Gima Motorcycles" },
                    { 16, null, "GasGas" },
                    { 17, null, "Sherco" },
                    { 18, null, "Scorpa" },
                    { 19, null, "Dnepr M-72" }
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
                    { 5, "Standard" },
                    { 6, "Street Fighter" },
                    { 7, "Dual Sport" },
                    { 8, "Custom" },
                    { 9, "Cafe Racer" },
                    { 10, "Stunt" },
                    { 11, "Trial" }
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
                    { 6, "Sweden" },
                    { 7, "Unated States of America" },
                    { 8, "Spain" },
                    { 9, "France" },
                    { 10, "Russia" }
                });

            migrationBuilder.InsertData(
                table: "GoldenClients",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359877777777", "81693837-9353-4dac-a5f2-4eade35a30f9" });

            migrationBuilder.InsertData(
                table: "Motorbikes",
                columns: new[] { "Id", "BrandId", "CategoryId", "CubicCentimeters", "Description", "GoldenClientId", "ImageUrl", "IsActive", "PricePerDay", "RenterId", "Variety" },
                values: new object[,]
                {
                    { 2, 2, 2, 450.00m, "This bike is for riding through mountains and off-road terrain!", 2, "https://www.motowag.com/wp-content/uploads/2022/05/honda-crf450x.jpg", false, 100.00m, null, "CRF" },
                    { 4, 7, 4, 1250.00m, "This bike is for long and comfortable riding on the road!", 2, "https://ultimatemotorcycling.com/wp-content/uploads/2021/07/2022-bmw-r-1250-rt-first-look-sport-touring-motorcycle-10.jpg", false, 200.00m, null, "R1250RT" },
                    { 6, 3, 6, 155.00m, "This bike is for riding on the road mostly in the city!", 2, "https://www.indiacarnews.com/wp-content/uploads/2019/03/Yamaha-MT-15-International.jpg", false, 100.00m, null, "MT-15" },
                    { 8, 10, 9, 1868.00m, "This bike outstanding cafe racer!", 2, "https://www.harley-davidson.com/content/dam/h-d/images/product-images/bikes/motorcycle/2022/2022-fat-boy-114/gallery/2022-fat-boy-114-motorcycle-g2.jpg?impolicy=myresize&rw=820", false, 200.00m, null, "Fat Boy" },
                    { 10, 6, 2, 300.00m, "This bike is magnificent mountain climber!", 2, "https://enduro21.com/images/2021/november-2021/2022-beta-300-rx/2022_beta_300_rx_1.jpg", false, 100.00m, null, "RR300 2T" }
                });

            migrationBuilder.InsertData(
                table: "Motorbikes",
                columns: new[] { "Id", "BrandId", "CategoryId", "CubicCentimeters", "Description", "GoldenClientId", "ImageUrl", "IsActive", "PricePerDay", "RenterId", "Variety" },
                values: new object[,]
                {
                    { 1, 1, 1, 250.00m, "This bike is for racing and amateur riding on a motocross track!", 1, "https://content2.kawasaki.com/ContentStorage/KMC/Products/8711/c5b45b1d-afef-445c-a721-671cf7b09dcb.png?w=850", false, 100.00m, null, "KX" },
                    { 3, 4, 3, 1300.00m, "This bike is for riding on the road and it's one of the fastest bikes ever!", 1, "https://dizzyriders.bg/uploads/thumbs/gallery/2021-02/fe6c02c5a7fe382814b184f1c9e0bb62-620x427.jpg", false, 200.00m, null, "Hayabusa" },
                    { 5, 8, 5, 900.00m, "This bike is for easy riding on the road!", 1, "https://imgd.aeplcdn.com/1280x720/bw/models/triumph-street-twin-2021-standard20210401131021.jpg?q=80", false, 100.00m, null, "Street Twin" },
                    { 7, 5, 7, 990.00m, "This adventure is for almost any terreain!", 1, "https://mcn-images.bauersecure.com/wp-images/19502/951x634/990_adventure_dakar.jpg?mode=max&quality=90&scale=down", false, 100.00m, null, "Adventure" },
                    { 9, 11, 9, 1811.00m, "This bike is greatest chief of indians!", 1, "https://www.webbikeworld.com/wp-content/uploads/2022/07/2022-Indian-Scout-Bobber-Sixty-4.jpg", false, 200.00m, null, "Super Chief" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CountryOfOriginId",
                table: "Brands",
                column: "CountryOfOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_GoldenClients_UserId",
                table: "GoldenClients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorbikes_BrandId",
                table: "Motorbikes",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorbikes_CategoryId",
                table: "Motorbikes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorbikes_GoldenClientId",
                table: "Motorbikes",
                column: "GoldenClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorbikes_RenterId",
                table: "Motorbikes",
                column: "RenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Motorbikes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "GoldenClients");

            migrationBuilder.DropTable(
                name: "CountriesOfOrigin");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
