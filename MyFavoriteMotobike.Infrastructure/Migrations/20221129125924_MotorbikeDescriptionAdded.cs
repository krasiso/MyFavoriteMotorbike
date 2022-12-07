using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFavoriteMotorbike.Infrastructure.Migrations
{
    public partial class MotorbikeDescriptionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
