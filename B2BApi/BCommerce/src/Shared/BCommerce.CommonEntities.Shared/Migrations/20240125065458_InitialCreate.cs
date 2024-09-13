using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BCommerce.CommonEntities.Shared.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "BCOMContinent",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMContinent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BCOMDocument",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Page = table.Column<string>(type: "text", nullable: false),
                    Mandatory = table.Column<string>(type: "text", nullable: false),
                    FileType = table.Column<string>(type: "text", nullable: false),
                    FileWidth = table.Column<string>(type: "text", nullable: false),
                    FileHeight = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMDocument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BCOMFieldType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Flex1 = table.Column<string>(type: "text", nullable: false),
                    Flex2 = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMFieldType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BCOMFunction",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PageName = table.Column<string>(type: "text", nullable: false),
                    PageLink = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMFunction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BCOMLanguage",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BCOMPrivilege",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMPrivilege", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BCOMProduct",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BCOMRole",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BCOMTheme",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMTheme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommonAuditLogs",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "text", nullable: false),
                    audittype = table.Column<string>(type: "text", nullable: false),
                    tablename = table.Column<string>(type: "text", nullable: false),
                    time_stamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    oldvalues = table.Column<string>(type: "text", nullable: false),
                    newvalues = table.Column<string>(type: "text", nullable: false),
                    affectedcolumns = table.Column<string>(type: "text", nullable: false),
                    primarykey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonAuditLogs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BCOMMarket",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ContinentId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMMarket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMMarket_BCOMContinent_ContinentId",
                        column: x => x.ContinentId,
                        principalSchema: "dbo",
                        principalTable: "BCOMContinent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMEventType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMEventType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMEventType_BCOMProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "BCOMProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMRoleDetails",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    FunctionId = table.Column<int>(type: "integer", nullable: false),
                    ViewAccess = table.Column<bool>(type: "boolean", nullable: false),
                    UpdateAccess = table.Column<bool>(type: "boolean", nullable: false),
                    SaveAccess = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteAccess = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMRoleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMRoleDetails_BCOMFunction_FunctionId",
                        column: x => x.FunctionId,
                        principalSchema: "dbo",
                        principalTable: "BCOMFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMRoleDetails_BCOMRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "BCOMRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMCountry",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MarketId = table.Column<int>(type: "integer", nullable: false),
                    Nationality = table.Column<string>(type: "text", nullable: false),
                    NationalityAR = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMCountry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMCountry_BCOMMarket_MarketId",
                        column: x => x.MarketId,
                        principalSchema: "dbo",
                        principalTable: "BCOMMarket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMCurrency",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    CurrencyCode = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMCurrency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMCurrency_BCOMCountry_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "BCOMCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMNationality",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMNationality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMNationality_BCOMCountry_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "BCOMCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMState",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMState_BCOMCountry_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "BCOMCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMCity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMCity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMCity_BCOMCountry_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "BCOMCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMCity_BCOMState_StateId",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "BCOMState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMAgentProfile",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address1 = table.Column<string>(type: "text", nullable: false),
                    Address2 = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    cityId = table.Column<int>(type: "integer", nullable: false),
                    Registration = table.Column<string>(type: "text", nullable: false),
                    AuthorizedPerson = table.Column<bool>(type: "boolean", nullable: false),
                    Doi = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    LedgerCode = table.Column<string>(type: "text", nullable: false),
                    Isiata = table.Column<string>(type: "text", nullable: false),
                    IATACode = table.Column<string>(type: "text", nullable: false),
                    POBox = table.Column<string>(type: "text", nullable: false),
                    LandPhone = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    Fax = table.Column<string>(type: "text", nullable: false),
                    Email1 = table.Column<string>(type: "text", nullable: false),
                    Email2 = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    Timezone = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    LogoPath = table.Column<string>(type: "text", nullable: false),
                    Theme = table.Column<string>(type: "text", nullable: false),
                    SalesUserId = table.Column<int>(type: "integer", nullable: false),
                    AMUserId = table.Column<int>(type: "integer", nullable: false),
                    ReceiptTotal = table.Column<string>(type: "text", nullable: false),
                    CurrentBalance = table.Column<string>(type: "text", nullable: false),
                    BlockStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMAgentProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMAgentProfile_BCOMAgentProfile_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "dbo",
                        principalTable: "BCOMAgentProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAgentProfile_BCOMCity_cityId",
                        column: x => x.cityId,
                        principalSchema: "dbo",
                        principalTable: "BCOMCity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAgentProfile_BCOMCountry_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "BCOMCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAgentProfile_BCOMCurrency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "dbo",
                        principalTable: "BCOMCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAgentProfile_BCOMLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "dbo",
                        principalTable: "BCOMLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAgentProfile_BCOMProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "BCOMProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAgentProfile_BCOMState_StateId",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "BCOMState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMSupplier",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    cityId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    LedgerCode = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Flex1 = table.Column<string>(type: "text", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    EndPoint1 = table.Column<string>(type: "text", nullable: false),
                    EndPoint2 = table.Column<string>(type: "text", nullable: false),
                    EndPoint3 = table.Column<string>(type: "text", nullable: false),
                    EndPoint4 = table.Column<string>(type: "text", nullable: false),
                    EndPoint5 = table.Column<string>(type: "text", nullable: false),
                    EndPoint6 = table.Column<string>(type: "text", nullable: false),
                    EndPoint7 = table.Column<string>(type: "text", nullable: false),
                    Credentials1 = table.Column<string>(type: "text", nullable: false),
                    Credentials2 = table.Column<string>(type: "text", nullable: false),
                    Credentials3 = table.Column<string>(type: "text", nullable: false),
                    Credentials4 = table.Column<string>(type: "text", nullable: false),
                    Credentials5 = table.Column<string>(type: "text", nullable: false),
                    Credentials6 = table.Column<string>(type: "text", nullable: false),
                    Credentials7 = table.Column<string>(type: "text", nullable: false),
                    Credentials8 = table.Column<string>(type: "text", nullable: false),
                    Credentials9 = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Mode = table.Column<string>(type: "text", nullable: false),
                    TechEmail = table.Column<string>(type: "text", nullable: false),
                    TechContact = table.Column<string>(type: "text", nullable: false),
                    SupplierAm = table.Column<string>(type: "text", nullable: false),
                    SupplierAmContact = table.Column<string>(type: "text", nullable: false),
                    ApiLastModified = table.Column<string>(type: "text", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMSupplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMSupplier_BCOMCity_cityId",
                        column: x => x.cityId,
                        principalSchema: "dbo",
                        principalTable: "BCOMCity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMSupplier_BCOMCountry_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "BCOMCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMSupplier_BCOMCurrency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "dbo",
                        principalTable: "BCOMCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMSupplier_BCOMProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "BCOMProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMSupplier_BCOMState_StateId",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "BCOMState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMAgentDoc",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    DocumentId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMAgentDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMAgentDoc_BCOMAgentProfile_AgentId",
                        column: x => x.AgentId,
                        principalSchema: "dbo",
                        principalTable: "BCOMAgentProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAgentDoc_BCOMDocument_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "BCOMDocument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMAgentFinance",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
                    CreditLimit = table.Column<string>(type: "text", nullable: false),
                    CreditLimitAlert = table.Column<string>(type: "text", nullable: false),
                    Security = table.Column<string>(type: "text", nullable: false),
                    TempCreditLimit = table.Column<string>(type: "text", nullable: false),
                    TempStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TempEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PayPeriod = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMAgentFinance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMAgentFinance_BCOMAgentProfile_AgentId",
                        column: x => x.AgentId,
                        principalSchema: "dbo",
                        principalTable: "BCOMAgentProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMAgentFOP",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMAgentFOP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMAgentFOP_BCOMAgentProfile_AgentId",
                        column: x => x.AgentId,
                        principalSchema: "dbo",
                        principalTable: "BCOMAgentProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMAgentPOC",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    ContactType = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Designation = table.Column<string>(type: "text", nullable: false),
                    LandPhone = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMAgentPOC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMAgentPOC_BCOMAgentProfile_AgentId",
                        column: x => x.AgentId,
                        principalSchema: "dbo",
                        principalTable: "BCOMAgentProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMLocation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Landphone = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Fax = table.Column<string>(type: "text", nullable: false),
                    TaxReg = table.Column<string>(type: "text", nullable: false),
                    Intergration = table.Column<string>(type: "text", nullable: false),
                    ParentAgentId = table.Column<string>(type: "text", nullable: false),
                    LedgerCode = table.Column<string>(type: "text", nullable: false),
                    Terms = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    BaseCurrency = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMLocation_BCOMAgentProfile_AgentId",
                        column: x => x.AgentId,
                        principalSchema: "dbo",
                        principalTable: "BCOMAgentProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMAgentSupplier",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    LedgerCode = table.Column<string>(type: "text", nullable: false),
                    IsPassive = table.Column<bool>(type: "boolean", nullable: false),
                    PrivateFareCode = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMAgentSupplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMAgentSupplier_BCOMAgentProfile_AgentId",
                        column: x => x.AgentId,
                        principalSchema: "dbo",
                        principalTable: "BCOMAgentProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAgentSupplier_BCOMProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "BCOMProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAgentSupplier_BCOMSupplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "dbo",
                        principalTable: "BCOMSupplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMAppConfig",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    BookingStatus = table.Column<bool>(type: "boolean", nullable: false),
                    AppKey = table.Column<string>(type: "text", nullable: false),
                    AppValue = table.Column<string>(type: "text", nullable: false),
                    PageFunctionId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMAppConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMAppConfig_BCOMFunction_PageFunctionId",
                        column: x => x.PageFunctionId,
                        principalSchema: "dbo",
                        principalTable: "BCOMFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAppConfig_BCOMProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "BCOMProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAppConfig_BCOMSupplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "dbo",
                        principalTable: "BCOMSupplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMExchangeRate",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    BaseCurrencyCode = table.Column<string>(type: "text", nullable: false),
                    ToCurrencyCode = table.Column<string>(type: "text", nullable: false),
                    BuyingRate = table.Column<string>(type: "text", nullable: false),
                    SellingRate = table.Column<string>(type: "text", nullable: false),
                    BufferType = table.Column<string>(type: "text", nullable: false),
                    BufferValue = table.Column<string>(type: "text", nullable: false),
                    AppliedRate = table.Column<string>(type: "text", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    FromDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMExchangeRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMExchangeRate_BCOMAgentProfile_AgentId",
                        column: x => x.AgentId,
                        principalSchema: "dbo",
                        principalTable: "BCOMAgentProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMExchangeRate_BCOMProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "BCOMProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMExchangeRate_BCOMSupplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "dbo",
                        principalTable: "BCOMSupplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMSupplierConfig",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AppKey = table.Column<string>(type: "text", nullable: false),
                    AppValue = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Flex1 = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMSupplierConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMSupplierConfig_BCOMSupplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "dbo",
                        principalTable: "BCOMSupplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMSupplierDocument",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    DocumentPath = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMSupplierDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMSupplierDocument_BCOMSupplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "dbo",
                        principalTable: "BCOMSupplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMAgentPg",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    locationId = table.Column<int>(type: "integer", nullable: false),
                    MerchantFee = table.Column<string>(type: "text", nullable: false),
                    BufferType = table.Column<string>(type: "text", nullable: false),
                    BufferValue = table.Column<string>(type: "text", nullable: false),
                    AppliedFee = table.Column<string>(type: "text", nullable: false),
                    LedgerCode = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMAgentPg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMAgentPg_BCOMAgentProfile_AgentId",
                        column: x => x.AgentId,
                        principalSchema: "dbo",
                        principalTable: "BCOMAgentProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAgentPg_BCOMLocation_locationId",
                        column: x => x.locationId,
                        principalSchema: "dbo",
                        principalTable: "BCOMLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAgentPg_BCOMProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "BCOMProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAgentPg_BCOMSupplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "dbo",
                        principalTable: "BCOMSupplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMUser",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<bool>(type: "boolean", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    AccessFieldId = table.Column<int>(type: "integer", nullable: false),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    SubAgentId = table.Column<int>(type: "integer", nullable: false),
                    locationId = table.Column<int>(type: "integer", nullable: false),
                    ChannelId = table.Column<int>(type: "integer", nullable: false),
                    IntegrationCode = table.Column<string>(type: "text", nullable: false),
                    AccessLocationId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    TwoFactorAuthenticationstatus = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorAuthenticationcomm = table.Column<string>(type: "text", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMUser_BCOMAgentProfile_AgentId",
                        column: x => x.AgentId,
                        principalSchema: "dbo",
                        principalTable: "BCOMAgentProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMUser_BCOMAgentProfile_SubAgentId",
                        column: x => x.SubAgentId,
                        principalSchema: "dbo",
                        principalTable: "BCOMAgentProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMUser_BCOMLocation_locationId",
                        column: x => x.locationId,
                        principalSchema: "dbo",
                        principalTable: "BCOMLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMAgentConfig",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    AppConfigId = table.Column<int>(type: "integer", nullable: false),
                    AppDescription = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMAgentConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMAgentConfig_BCOMAgentProfile_AgentId",
                        column: x => x.AgentId,
                        principalSchema: "dbo",
                        principalTable: "BCOMAgentProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMAgentConfig_BCOMAppConfig_AppConfigId",
                        column: x => x.AppConfigId,
                        principalSchema: "dbo",
                        principalTable: "BCOMAppConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMUserprivilege",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConfigId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    privillageId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMUserprivilege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMUserprivilege_BCOMAppConfig_ConfigId",
                        column: x => x.ConfigId,
                        principalSchema: "dbo",
                        principalTable: "BCOMAppConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMUserprivilege_BCOMPrivilege_privillageId",
                        column: x => x.privillageId,
                        principalSchema: "dbo",
                        principalTable: "BCOMPrivilege",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMUserprivilege_BCOMUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "BCOMUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BCOMUserRole",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCOMUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCOMUserRole_BCOMRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "BCOMRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BCOMUserRole_BCOMUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "BCOMUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentConfig_AgentId",
                schema: "dbo",
                table: "BCOMAgentConfig",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentConfig_AppConfigId",
                schema: "dbo",
                table: "BCOMAgentConfig",
                column: "AppConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentDoc_AgentId",
                schema: "dbo",
                table: "BCOMAgentDoc",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentDoc_DocumentId",
                schema: "dbo",
                table: "BCOMAgentDoc",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentFinance_AgentId",
                schema: "dbo",
                table: "BCOMAgentFinance",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentFOP_AgentId",
                schema: "dbo",
                table: "BCOMAgentFOP",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentPg_AgentId",
                schema: "dbo",
                table: "BCOMAgentPg",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentPg_locationId",
                schema: "dbo",
                table: "BCOMAgentPg",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentPg_ProductId",
                schema: "dbo",
                table: "BCOMAgentPg",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentPg_SupplierId",
                schema: "dbo",
                table: "BCOMAgentPg",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentPOC_AgentId",
                schema: "dbo",
                table: "BCOMAgentPOC",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentProfile_cityId",
                schema: "dbo",
                table: "BCOMAgentProfile",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentProfile_CountryId",
                schema: "dbo",
                table: "BCOMAgentProfile",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentProfile_CurrencyId",
                schema: "dbo",
                table: "BCOMAgentProfile",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentProfile_LanguageId",
                schema: "dbo",
                table: "BCOMAgentProfile",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentProfile_ParentId",
                schema: "dbo",
                table: "BCOMAgentProfile",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentProfile_ProductId",
                schema: "dbo",
                table: "BCOMAgentProfile",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentProfile_StateId",
                schema: "dbo",
                table: "BCOMAgentProfile",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentSupplier_AgentId",
                schema: "dbo",
                table: "BCOMAgentSupplier",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentSupplier_ProductId",
                schema: "dbo",
                table: "BCOMAgentSupplier",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAgentSupplier_SupplierId",
                schema: "dbo",
                table: "BCOMAgentSupplier",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAppConfig_PageFunctionId",
                schema: "dbo",
                table: "BCOMAppConfig",
                column: "PageFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAppConfig_ProductId",
                schema: "dbo",
                table: "BCOMAppConfig",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMAppConfig_SupplierId",
                schema: "dbo",
                table: "BCOMAppConfig",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMCity_CountryId",
                schema: "dbo",
                table: "BCOMCity",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMCity_StateId",
                schema: "dbo",
                table: "BCOMCity",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMCountry_MarketId",
                schema: "dbo",
                table: "BCOMCountry",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMCurrency_CountryId",
                schema: "dbo",
                table: "BCOMCurrency",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMEventType_ProductId",
                schema: "dbo",
                table: "BCOMEventType",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMExchangeRate_AgentId",
                schema: "dbo",
                table: "BCOMExchangeRate",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMExchangeRate_ProductId",
                schema: "dbo",
                table: "BCOMExchangeRate",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMExchangeRate_SupplierId",
                schema: "dbo",
                table: "BCOMExchangeRate",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMLocation_AgentId",
                schema: "dbo",
                table: "BCOMLocation",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMMarket_ContinentId",
                schema: "dbo",
                table: "BCOMMarket",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMNationality_CountryId",
                schema: "dbo",
                table: "BCOMNationality",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMRoleDetails_FunctionId",
                schema: "dbo",
                table: "BCOMRoleDetails",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMRoleDetails_RoleId",
                schema: "dbo",
                table: "BCOMRoleDetails",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMState_CountryId",
                schema: "dbo",
                table: "BCOMState",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMSupplier_cityId",
                schema: "dbo",
                table: "BCOMSupplier",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMSupplier_CountryId",
                schema: "dbo",
                table: "BCOMSupplier",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMSupplier_CurrencyId",
                schema: "dbo",
                table: "BCOMSupplier",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMSupplier_ProductId",
                schema: "dbo",
                table: "BCOMSupplier",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMSupplier_StateId",
                schema: "dbo",
                table: "BCOMSupplier",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMSupplierConfig_SupplierId",
                schema: "dbo",
                table: "BCOMSupplierConfig",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMSupplierDocument_SupplierId",
                schema: "dbo",
                table: "BCOMSupplierDocument",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMUser_AgentId",
                schema: "dbo",
                table: "BCOMUser",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMUser_locationId",
                schema: "dbo",
                table: "BCOMUser",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMUser_SubAgentId",
                schema: "dbo",
                table: "BCOMUser",
                column: "SubAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMUserprivilege_ConfigId",
                schema: "dbo",
                table: "BCOMUserprivilege",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMUserprivilege_privillageId",
                schema: "dbo",
                table: "BCOMUserprivilege",
                column: "privillageId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMUserprivilege_UserId",
                schema: "dbo",
                table: "BCOMUserprivilege",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMUserRole_RoleId",
                schema: "dbo",
                table: "BCOMUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BCOMUserRole_UserId",
                schema: "dbo",
                table: "BCOMUserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BCOMAgentConfig",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMAgentDoc",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMAgentFinance",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMAgentFOP",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMAgentPg",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMAgentPOC",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMAgentSupplier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMEventType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMExchangeRate",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMFieldType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMNationality",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMRoleDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMSupplierConfig",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMSupplierDocument",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMTheme",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMUserprivilege",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMUserRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CommonAuditLogs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMDocument",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMAppConfig",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMPrivilege",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMUser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMFunction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMSupplier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMLocation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMAgentProfile",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMCity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMCurrency",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMLanguage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMProduct",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMState",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMCountry",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMMarket",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BCOMContinent",
                schema: "dbo");
        }
    }
}
