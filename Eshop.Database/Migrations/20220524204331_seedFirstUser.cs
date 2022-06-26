using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshop.Database.Migrations
{
    public partial class seedFirstUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbi",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserRole" },
                values: new object[,]
                {
                    { new Guid("2bb9c6d4-5a71-4f2f-8aa0-6fd7c9b18821"), "f24f9813-9d80-402d-839e-fdec6a705223", "Customer", null, 5 },
                    { new Guid("81fef003-04af-4fdc-b67d-93c947eb3575"), "efe2e89d-d35d-40cc-87e9-53e7fb62dfc0", "FullAdmin", null, 1 },
                    { new Guid("ca7c5a2b-4356-45d7-b567-ae3f755d33df"), "b28d60d4-4ece-4574-aacf-e1c9120f7353", "System", null, 0 },
                    { new Guid("cf15298a-7b4a-4cce-9649-7a687bb0aa60"), "992f8ebd-c418-40fe-a200-dc814c393fda", "ShopAdmin", null, 2 },
                    { new Guid("ed7333d7-0efb-4756-9a7b-621258ab76ec"), "77c1552e-6e50-454b-8bd0-c210bced7488", "UserAdmin", null, 4 },
                    { new Guid("fab84446-3898-4c6e-8cea-0c352263d48a"), "1493bc86-bfee-4ff3-bb94-3f10405521fa", "StorageAdmin", null, 3 }
                });

            migrationBuilder.InsertData(
                schema: "dbi",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b9072622-bd0e-4cd1-8e32-6360fc5580d6"), 0, "09ff5723-c950-45c2-b3ef-1a6bf01aef41", "fullAdmin@eshop.com", false, "FullAdmin", "FullAdmin", false, null, null, null, "AQAAAAEAACcQAAAAEDTnhz/bh4bnrxphMIkJ8OL1kYiniczYLSzIpNwMauQu0WxHCK8tv2qSJMNlcGN/fQ==", null, false, null, false, "Admin" });

            migrationBuilder.InsertData(
                schema: "dbi",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "ApplicationRoleId", "ApplicationUserId" },
                values: new object[] { new Guid("81fef003-04af-4fdc-b67d-93c947eb3575"), new Guid("b9072622-bd0e-4cd1-8e32-6360fc5580d6"), null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2bb9c6d4-5a71-4f2f-8aa0-6fd7c9b18821"));

            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ca7c5a2b-4356-45d7-b567-ae3f755d33df"));

            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cf15298a-7b4a-4cce-9649-7a687bb0aa60"));

            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ed7333d7-0efb-4756-9a7b-621258ab76ec"));

            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fab84446-3898-4c6e-8cea-0c352263d48a"));

            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("81fef003-04af-4fdc-b67d-93c947eb3575"), new Guid("b9072622-bd0e-4cd1-8e32-6360fc5580d6") });

            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("81fef003-04af-4fdc-b67d-93c947eb3575"));

            migrationBuilder.DeleteData(
                schema: "dbi",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9072622-bd0e-4cd1-8e32-6360fc5580d6"));
        }
    }
}
