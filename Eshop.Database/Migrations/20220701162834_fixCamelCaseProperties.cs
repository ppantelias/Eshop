using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshop.Database.Migrations
{
    public partial class fixCamelCaseProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2ab07f0a-ff34-467d-9bb6-f374ea1b8e60"));

            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4442cc9f-7054-443a-89a3-be702ab9ed14"));

            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7791bc6c-1242-49b1-a644-99052ecf730c"));

            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d1a7e104-641f-40a0-824d-9e4fd643a07c"));

            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fdcd4255-14e9-4522-9df1-24e1ddb577d1"));

            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3fac61bc-7476-44b6-88e5-25cad8362a62"), new Guid("14b68c5c-b990-4038-857a-b70a65ced3dd") });

            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3fac61bc-7476-44b6-88e5-25cad8362a62"));

            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("14b68c5c-b990-4038-857a-b70a65ced3dd"));

            migrationBuilder.RenameColumn(
                name: "Lastname",
                schema: "dbi",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                schema: "dbi",
                table: "Users",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "dbi",
                table: "Users",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "dbi",
                table: "Users",
                newName: "Firstname");

            migrationBuilder.InsertData(
                schema: "dbi",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserRole" },
                values: new object[,]
                {
                    { new Guid("2ab07f0a-ff34-467d-9bb6-f374ea1b8e60"), "03a5141e-f813-4b8f-a9d0-eeea05d1f786", "ShopAdmin", null, 2 },
                    { new Guid("3fac61bc-7476-44b6-88e5-25cad8362a62"), "b1a2b1d4-b9e2-4f64-b39a-ecd8e1ee0477", "FullAdmin", null, 1 },
                    { new Guid("4442cc9f-7054-443a-89a3-be702ab9ed14"), "34bfba84-7fa0-4127-b459-9e65ebcb60ad", "UserAdmin", null, 4 },
                    { new Guid("7791bc6c-1242-49b1-a644-99052ecf730c"), "7b6574ff-82c8-4449-ae39-676fbefe554e", "StorageAdmin", null, 3 },
                    { new Guid("d1a7e104-641f-40a0-824d-9e4fd643a07c"), "7e521a3c-9764-4417-aef9-9b46544acc0d", "System", null, 0 },
                    { new Guid("fdcd4255-14e9-4522-9df1-24e1ddb577d1"), "69906d89-acff-418c-957d-7432a4b66bc6", "Customer", null, 5 }
                });

            migrationBuilder.InsertData(
                schema: "dbi",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("14b68c5c-b990-4038-857a-b70a65ced3dd"), 0, "e85927f5-97d7-4b69-a0c3-375ce5211253", "fullAdmin@eshop.com", false, "FullAdmin", "FullAdmin", false, null, null, null, "AQAAAAEAACcQAAAAEIpJbDjFE6e7f01IM29NSwvPpiXptfAGDaRBzX+ZF1L3+LRP+IIvCxDxIc5WBoffvg==", null, false, null, false, "Admin" });

            migrationBuilder.InsertData(
                schema: "dbi",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("3fac61bc-7476-44b6-88e5-25cad8362a62"), new Guid("14b68c5c-b990-4038-857a-b70a65ced3dd") });
        }
    }
}
