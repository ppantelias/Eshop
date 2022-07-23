using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshop.Database.Migrations
{
    public partial class identityNavProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_ApplicationRoleId",
                schema: "dbi",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_ApplicationUserId",
                schema: "dbi",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_ApplicationUserId",
                schema: "dbi",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_ApplicationRoleId",
                schema: "dbi",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_ApplicationUserId",
                schema: "dbi",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_ApplicationUserId",
                schema: "dbi",
                table: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserTokens_ApplicationUserId",
                schema: "dbi",
                table: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_ApplicationRoleId",
                schema: "dbi",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_ApplicationUserId",
                schema: "dbi",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserLogins_ApplicationUserId",
                schema: "dbi",
                table: "UserLogins");

            migrationBuilder.DropIndex(
                name: "IX_UserClaims_ApplicationUserId",
                schema: "dbi",
                table: "UserClaims");

            migrationBuilder.DropIndex(
                name: "IX_RoleClaims_ApplicationRoleId",
                schema: "dbi",
                table: "RoleClaims");

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

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "dbi",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "ApplicationRoleId",
                schema: "dbi",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "dbi",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "dbi",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "dbi",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "ApplicationRoleId",
                schema: "dbi",
                table: "RoleClaims");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                schema: "dbi",
                table: "UserTokens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationRoleId",
                schema: "dbi",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                schema: "dbi",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                schema: "dbi",
                table: "UserLogins",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                schema: "dbi",
                table: "UserClaims",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationRoleId",
                schema: "dbi",
                table: "RoleClaims",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_ApplicationUserId",
                schema: "dbi",
                table: "UserTokens",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_ApplicationRoleId",
                schema: "dbi",
                table: "UserRoles",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_ApplicationUserId",
                schema: "dbi",
                table: "UserRoles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_ApplicationUserId",
                schema: "dbi",
                table: "UserLogins",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_ApplicationUserId",
                schema: "dbi",
                table: "UserClaims",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_ApplicationRoleId",
                schema: "dbi",
                table: "RoleClaims",
                column: "ApplicationRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_ApplicationRoleId",
                schema: "dbi",
                table: "RoleClaims",
                column: "ApplicationRoleId",
                principalSchema: "dbi",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_ApplicationUserId",
                schema: "dbi",
                table: "UserClaims",
                column: "ApplicationUserId",
                principalSchema: "dbi",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_ApplicationUserId",
                schema: "dbi",
                table: "UserLogins",
                column: "ApplicationUserId",
                principalSchema: "dbi",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_ApplicationRoleId",
                schema: "dbi",
                table: "UserRoles",
                column: "ApplicationRoleId",
                principalSchema: "dbi",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_ApplicationUserId",
                schema: "dbi",
                table: "UserRoles",
                column: "ApplicationUserId",
                principalSchema: "dbi",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_ApplicationUserId",
                schema: "dbi",
                table: "UserTokens",
                column: "ApplicationUserId",
                principalSchema: "dbi",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}