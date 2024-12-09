using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Test_UserChangePass.Migrations
{
    /// <inheritdoc />
    public partial class s1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Userx",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Password_Test = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userx", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Userx",
                columns: new[] { "Id", "Email", "IsAdmin", "PasswordHash", "Password_Test", "RegisterDate", "UserName" },
                values: new object[,]
                {
                    { 1, "soheil0910line@gmail.com", true, "$2a$11$fnBnKh.p4EQ41qXFizFg2OosqrAohja88s872pICM5kEzsQX4ImNy", "1234", new DateTime(2024, 12, 9, 15, 44, 10, 805, DateTimeKind.Utc).AddTicks(5484), "user1" },
                    { 2, "soheil0910line@gmail.com", false, "$2a$11$iIqZ9YT7IBtmxGrwtEh3RuvxPlibFxWJeHfs7pvMAqjCCB7/z78QO", "1234", new DateTime(2024, 12, 9, 15, 44, 11, 124, DateTimeKind.Utc).AddTicks(9861), "user2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Userx");
        }
    }
}
