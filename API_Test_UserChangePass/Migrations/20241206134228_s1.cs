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
                    { 1, "soheil0910line@gmail.com", true, "$2a$11$GnollM3pFs6N7hMuIK3uZ.1CHNnUYQcru0CxM6SRxoM974aIE1UmS", "1234", new DateTime(2024, 12, 6, 13, 42, 27, 743, DateTimeKind.Utc).AddTicks(83), "user1" },
                    { 2, "soheil0910line@gmail.com", false, "$2a$11$qI2Jf5WkueA/8V1py0iUP.5bhlWPrckwzrQfOc4qNF5kHigU2qMTm", "1234", new DateTime(2024, 12, 6, 13, 42, 28, 4, DateTimeKind.Utc).AddTicks(4370), "user2" }
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
