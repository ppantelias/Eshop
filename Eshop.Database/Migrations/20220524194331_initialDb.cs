using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshop.Database.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbi");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "dbi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "dbi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalSchema: "dbi",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbi",
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RootId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_Categories_RootId",
                        column: x => x.RootId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    MobileNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    IsMember = table.Column<bool>(type: "bit", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Discounts_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Discounts_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MembershipTiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LoyaltyWeight = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    LowerLimitPoints = table.Column<int>(type: "int", nullable: false),
                    HigherLimitPoints = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembershipTiers_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MembershipTiers_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MembershipTiers_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Origins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Abbreviation = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Origins_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Origins_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Origins_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SoldProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StartingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CouponId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Returned = table.Column<bool>(type: "bit", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldProducts_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SoldProducts_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SoldProducts_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "dbi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "dbi",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "dbi",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalSchema: "dbi",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbi",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "dbi",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EncryptedInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShipmentInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    MobileNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Appartment = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentInfos_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShipmentInfos_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShipmentInfos_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShipmentInfos_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryDiscount",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDiscount", x => new { x.CategoriesId, x.DiscountsId });
                    table.ForeignKey(
                        name: "FK_CategoryDiscount_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoryDiscount_Discounts_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoyaltyMemberships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoyaltyPoints = table.Column<int>(type: "int", nullable: false),
                    TotalLoyaltyPointsGained = table.Column<int>(type: "int", nullable: false),
                    TotalLoyaltyPointsRedeemed = table.Column<int>(type: "int", nullable: false),
                    Consent = table.Column<bool>(type: "bit", nullable: false),
                    MembershipTierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoyaltyMemberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoyaltyMemberships_MembershipTiers_MembershipTierId",
                        column: x => x.MembershipTierId,
                        principalTable: "MembershipTiers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoyaltyMemberships_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoyaltyMemberships_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoyaltyMemberships_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Origins_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Brands_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Brands_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Brands_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ShipmentInfos_ShipmentInfoId",
                        column: x => x.ShipmentInfoId,
                        principalTable: "ShipmentInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaxRedemptionTimes = table.Column<int>(type: "int", nullable: false),
                    RedeemedTimes = table.Column<int>(type: "int", nullable: false),
                    IsRedeemed = table.Column<bool>(type: "bit", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    LoyaltyMembershipId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_LoyaltyMemberships_LoyaltyMembershipId",
                        column: x => x.LoyaltyMembershipId,
                        principalTable: "LoyaltyMemberships",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Coupons_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Coupons_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Coupons_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerLoyaltyMembership",
                columns: table => new
                {
                    CustomersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoyaltyMembershipsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLoyaltyMembership", x => new { x.CustomersId, x.LoyaltyMembershipsId });
                    table.ForeignKey(
                        name: "FK_CustomerLoyaltyMembership_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerLoyaltyMembership_LoyaltyMemberships_LoyaltyMembershipsId",
                        column: x => x.LoyaltyMembershipsId,
                        principalTable: "LoyaltyMemberships",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BrandCategory",
                columns: table => new
                {
                    BrandsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandCategory", x => new { x.BrandsId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_BrandCategory_Brands_BrandsId",
                        column: x => x.BrandsId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BrandCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BrandDiscount",
                columns: table => new
                {
                    BrandsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandDiscount", x => new { x.BrandsId, x.DiscountsId });
                    table.ForeignKey(
                        name: "FK_BrandDiscount_Brands_BrandsId",
                        column: x => x.BrandsId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BrandDiscount_Discounts_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsNewArrival = table.Column<bool>(type: "bit", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoyaltyPointsUsed = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashOnDeliveryCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValueBeforeTaxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentInfos_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentInfos_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentInfos_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentInfos_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BrandCoupon",
                columns: table => new
                {
                    BrandsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CouponsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandCoupon", x => new { x.BrandsId, x.CouponsId });
                    table.ForeignKey(
                        name: "FK_BrandCoupon_Brands_BrandsId",
                        column: x => x.BrandsId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BrandCoupon_Coupons_CouponsId",
                        column: x => x.CouponsId,
                        principalTable: "Coupons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryCoupon",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CouponsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCoupon", x => new { x.CategoriesId, x.CouponsId });
                    table.ForeignKey(
                        name: "FK_CategoryCoupon_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoryCoupon_Coupons_CouponsId",
                        column: x => x.CouponsId,
                        principalTable: "Coupons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CouponCustomer",
                columns: table => new
                {
                    CouponsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponCustomer", x => new { x.CouponsId, x.CustomersId });
                    table.ForeignKey(
                        name: "FK_CouponCustomer_Coupons_CouponsId",
                        column: x => x.CouponsId,
                        principalTable: "Coupons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CouponCustomer_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CouponProduct",
                columns: table => new
                {
                    CouponsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponProduct", x => new { x.CouponsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CouponProduct_Coupons_CouponsId",
                        column: x => x.CouponsId,
                        principalTable: "Coupons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CouponProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiscountProduct",
                columns: table => new
                {
                    DiscountsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountProduct", x => new { x.DiscountsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_DiscountProduct_Discounts_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stock_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stock_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stock_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartCoupon",
                columns: table => new
                {
                    CartsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CouponsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartCoupon", x => new { x.CartsId, x.CouponsId });
                    table.ForeignKey(
                        name: "FK_CartCoupon_Carts_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartCoupon_Coupons_CouponsId",
                        column: x => x.CouponsId,
                        principalTable: "Coupons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CouponId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartProducts_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartProducts_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartProducts_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderStocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStocks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderStocks_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderStocks_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderStocks_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderStocks_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StocksOnHold",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false),
                    UserCreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocksOnHold", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StocksOnHold_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StocksOnHold_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StocksOnHold_Users_UserDeletedById",
                        column: x => x.UserDeletedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StocksOnHold_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalSchema: "dbi",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandCategory_CategoriesId",
                table: "BrandCategory",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandCoupon_CouponsId",
                table: "BrandCoupon",
                column: "CouponsId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandDiscount_DiscountsId",
                table: "BrandDiscount",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_OriginId",
                table: "Brands",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_UserCreatedById",
                table: "Brands",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_UserDeletedById",
                table: "Brands",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_UserUpdatedById",
                table: "Brands",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CustomerId",
                table: "Cards",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserCreatedById",
                table: "Cards",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserDeletedById",
                table: "Cards",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserUpdatedById",
                table: "Cards",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CartCoupon_CouponsId",
                table: "CartCoupon",
                column: "CouponsId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_CartId",
                table: "CartProducts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_UserCreatedById",
                table: "CartProducts",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_UserDeletedById",
                table: "CartProducts",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_UserUpdatedById",
                table: "CartProducts",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_DiscountId",
                table: "Carts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_OrderId",
                table: "Carts",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserCreatedById",
                table: "Carts",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserDeletedById",
                table: "Carts",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserUpdatedById",
                table: "Carts",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RootId",
                table: "Categories",
                column: "RootId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserCreatedById",
                table: "Categories",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserDeletedById",
                table: "Categories",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserUpdatedById",
                table: "Categories",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCoupon_CouponsId",
                table: "CategoryCoupon",
                column: "CouponsId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDiscount_DiscountsId",
                table: "CategoryDiscount",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponCustomer_CustomersId",
                table: "CouponCustomer",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponProduct_ProductsId",
                table: "CouponProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_LoyaltyMembershipId",
                table: "Coupons",
                column: "LoyaltyMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_UserCreatedById",
                table: "Coupons",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_UserDeletedById",
                table: "Coupons",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_UserUpdatedById",
                table: "Coupons",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLoyaltyMembership_LoyaltyMembershipsId",
                table: "CustomerLoyaltyMembership",
                column: "LoyaltyMembershipsId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserCreatedById",
                table: "Customers",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserDeletedById",
                table: "Customers",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserUpdatedById",
                table: "Customers",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProduct_ProductsId",
                table: "DiscountProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_UserCreatedById",
                table: "Discounts",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_UserDeletedById",
                table: "Discounts",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_UserUpdatedById",
                table: "Discounts",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserCreatedById",
                table: "Images",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserDeletedById",
                table: "Images",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserUpdatedById",
                table: "Images",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyMemberships_MembershipTierId",
                table: "LoyaltyMemberships",
                column: "MembershipTierId");

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyMemberships_UserCreatedById",
                table: "LoyaltyMemberships",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyMemberships_UserDeletedById",
                table: "LoyaltyMemberships",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyMemberships_UserUpdatedById",
                table: "LoyaltyMemberships",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipTiers_UserCreatedById",
                table: "MembershipTiers",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipTiers_UserDeletedById",
                table: "MembershipTiers",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipTiers_UserUpdatedById",
                table: "MembershipTiers",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipmentInfoId",
                table: "Orders",
                column: "ShipmentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserCreatedById",
                table: "Orders",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserDeletedById",
                table: "Orders",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserUpdatedById",
                table: "Orders",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStocks_OrderId",
                table: "OrderStocks",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStocks_StockId",
                table: "OrderStocks",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStocks_UserCreatedById",
                table: "OrderStocks",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStocks_UserDeletedById",
                table: "OrderStocks",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStocks_UserUpdatedById",
                table: "OrderStocks",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Origins_UserCreatedById",
                table: "Origins",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Origins_UserDeletedById",
                table: "Origins",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Origins_UserUpdatedById",
                table: "Origins",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfos_OrderId",
                table: "PaymentInfos",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfos_UserCreatedById",
                table: "PaymentInfos",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfos_UserDeletedById",
                table: "PaymentInfos",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfos_UserUpdatedById",
                table: "PaymentInfos",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserCreatedById",
                table: "Products",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserDeletedById",
                table: "Products",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserUpdatedById",
                table: "Products",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_ApplicationRoleId",
                schema: "dbi",
                table: "RoleClaims",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "dbi",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbi",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentInfos_CustomerId",
                table: "ShipmentInfos",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentInfos_UserCreatedById",
                table: "ShipmentInfos",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentInfos_UserDeletedById",
                table: "ShipmentInfos",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentInfos_UserUpdatedById",
                table: "ShipmentInfos",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SoldProducts_UserCreatedById",
                table: "SoldProducts",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SoldProducts_UserDeletedById",
                table: "SoldProducts",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_SoldProducts_UserUpdatedById",
                table: "SoldProducts",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                table: "Stock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_UserCreatedById",
                table: "Stock",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_UserDeletedById",
                table: "Stock",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_UserUpdatedById",
                table: "Stock",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StocksOnHold_StockId",
                table: "StocksOnHold",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_StocksOnHold_UserCreatedById",
                table: "StocksOnHold",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StocksOnHold_UserDeletedById",
                table: "StocksOnHold",
                column: "UserDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_StocksOnHold_UserUpdatedById",
                table: "StocksOnHold",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_ApplicationUserId",
                schema: "dbi",
                table: "UserClaims",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "dbi",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_ApplicationUserId",
                schema: "dbi",
                table: "UserLogins",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "dbi",
                table: "UserLogins",
                column: "UserId");

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
                name: "IX_UserRoles_RoleId",
                schema: "dbi",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbi",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbi",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_ApplicationUserId",
                schema: "dbi",
                table: "UserTokens",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandCategory");

            migrationBuilder.DropTable(
                name: "BrandCoupon");

            migrationBuilder.DropTable(
                name: "BrandDiscount");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "CartCoupon");

            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "CategoryCoupon");

            migrationBuilder.DropTable(
                name: "CategoryDiscount");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "CouponCustomer");

            migrationBuilder.DropTable(
                name: "CouponProduct");

            migrationBuilder.DropTable(
                name: "CustomerLoyaltyMembership");

            migrationBuilder.DropTable(
                name: "DiscountProduct");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderStocks");

            migrationBuilder.DropTable(
                name: "PaymentInfos");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "dbi");

            migrationBuilder.DropTable(
                name: "SoldProducts");

            migrationBuilder.DropTable(
                name: "StocksOnHold");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "dbi");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "dbi");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "dbi");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "dbi");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "dbi");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "LoyaltyMemberships");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShipmentInfos");

            migrationBuilder.DropTable(
                name: "MembershipTiers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Origins");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbi");
        }
    }
}
