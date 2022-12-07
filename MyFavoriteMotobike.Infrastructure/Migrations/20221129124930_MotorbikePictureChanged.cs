using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFavoriteMotorbike.Infrastructure.Migrations
{
    public partial class MotorbikePictureChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81693837-9353-4dac-a5f2-4eade35a30f9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d7e0644-9b18-4b18-a79d-3985e5d7a45a", "AQAAAAEAACcQAAAAEMX4z2EugaEiKleigO4CbVAhaQdoHFSphmbPTMU1IoNu+LLowhU6fUoGIjJEGn+84g==", "7551f1d2-6f92-494f-9037-44d972cb5a01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8700b0e1-1cc6-4e31-81d8-0dc734f1d679",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1686889-1c94-441e-aaff-7e4feec27c1c", "AQAAAAEAACcQAAAAEOnzUJSMdA2vXsGSEtxA3TJ5YVCO6gZ65xJ3kFpXDemzCTeKtgkUGlOpheDbKaDiiw==", "d221f664-2a27-488f-8abd-c32e5f4c10a7" });

            migrationBuilder.UpdateData(
                table: "Motorbikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://content2.kawasaki.com/ContentStorage/KMC/Products/8711/c5b45b1d-afef-445c-a721-671cf7b09dcb.png?w=850");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Motorbikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://xoffroad.dueruote.it/content/dam/xoffroad/it/news/moto/2020/10/13/hot-news-arrivano-le-kawasaki-kx-250-450-x/gallery/rsmall/kawa%201.jpg");
        }
    }
}
