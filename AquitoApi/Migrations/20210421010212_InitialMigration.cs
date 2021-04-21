using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AquitoApi.Migrations
{
    public partial class InitialMigration : Migration
    {


        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
            .DropTable("reservation");
            migrationBuilder
            .DropTable("vehicle");
            migrationBuilder
            .DropTable("client");


            migrationBuilder
            .DropTable("typevehicle");

            migrationBuilder.DropTable("useraquito");



            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });


            migrationBuilder
            .CreateTable(
                name: "typevehicle",
                columns: table => new
                {
                    typevehicleid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    namevehicle = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typevehicle", x => x.typevehicleid);
                });

            migrationBuilder.CreateTable(
                name: "useraquito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    lastname = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_useraquito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_useraquito_UserId",
                        column: x => x.UserId,
                        principalTable: "useraquito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_useraquito_UserId",
                        column: x => x.UserId,
                        principalTable: "useraquito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_AspNetUserRoles_useraquito_UserId",
                        column: x => x.UserId,
                        principalTable: "useraquito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_useraquito_UserId",
                        column: x => x.UserId,
                        principalTable: "useraquito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    clientid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    cedula = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    firstname = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    lastname = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    licence = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    nacionality = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    typeblood = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    userpic = table.Column<string>(type: "character varying(650)", maxLength: 650, nullable: true),
                    licencepic = table.Column<string>(type: "character varying(650)", maxLength: 650, nullable: true),
                    useraquitoid = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.clientid);
                    table.ForeignKey(
                        name: "fk_useraquito_client",
                        column: x => x.useraquitoid,
                        principalTable: "useraquito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vehicle",
                columns: table => new
                {
                    vehicleid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    brand = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    model = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    age = table.Column<int>(type: "integer", nullable: true),
                    priceday = table.Column<decimal>(type: "numeric", nullable: true),
                    weightcapacity = table.Column<decimal>(type: "numeric", nullable: true),
                    passengers = table.Column<int>(type: "integer", nullable: true),
                    matricula = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    securitynum = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    vehiclepic = table.Column<string>(type: "character varying(650)", maxLength: 650, nullable: true),
                    latitude = table.Column<decimal>(type: "numeric", nullable: true),
                    longitude = table.Column<decimal>(type: "numeric", nullable: true),
                    typevehicleid = table.Column<int>(type: "integer", nullable: true),
                    useraquitoid = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle", x => x.vehicleid);
                    table.ForeignKey(
                        name: "fk_typevehicle_vehicle",
                        column: x => x.typevehicleid,
                        principalTable: "typevehicle",
                        principalColumn: "typevehicleid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_useraquito_vehicle",
                        column: x => x.useraquitoid,
                        principalTable: "useraquito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    reservationid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    startdate = table.Column<DateTime>(type: "date", nullable: true),
                    enddate = table.Column<DateTime>(type: "date", nullable: true),
                    totalpay = table.Column<decimal>(type: "numeric", nullable: true),
                    vehicleid = table.Column<int>(type: "integer", nullable: true),
                    clientid = table.Column<int>(type: "integer", nullable: true),
                    useraquitoid = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.reservationid);
                    table.ForeignKey(
                        name: "fk_client_reservation",
                        column: x => x.clientid,
                        principalTable: "client",
                        principalColumn: "clientid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_useraquito_reservation",
                        column: x => x.useraquitoid,
                        principalTable: "useraquito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_vehicle_reservation",
                        column: x => x.vehicleid,
                        principalTable: "vehicle",
                        principalColumn: "vehicleid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_client_useraquitoid",
                table: "client",
                column: "useraquitoid");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_clientid",
                table: "reservation",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_useraquitoid",
                table: "reservation",
                column: "useraquitoid");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_vehicleid",
                table: "reservation",
                column: "vehicleid");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "useraquito",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "useraquito",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_typevehicleid",
                table: "vehicle",
                column: "typevehicleid");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_useraquitoid",
                table: "vehicle",
                column: "useraquitoid");
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
                name: "reservation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "vehicle");

            migrationBuilder.DropTable(
                name: "typevehicle");

            migrationBuilder.DropTable(
                name: "useraquito");
        }
    }
}
