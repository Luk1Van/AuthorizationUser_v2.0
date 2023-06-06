using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace User.DbContext.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_Groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_Groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_States",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_States", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    user_group_id = table.Column<int>(type: "integer", nullable: false),
                    user_state_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_user_Groups_user_group_id",
                        column: x => x.user_group_id,
                        principalTable: "user_Groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_user_States_user_state_id",
                        column: x => x.user_state_id,
                        principalTable: "user_States",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "user_Groups",
                columns: new[] { "id", "code", "description" },
                values: new object[,]
                {
                    { 1, "User", "Regular user" },
                    { 2, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "user_States",
                columns: new[] { "id", "code", "description" },
                values: new object[,]
                {
                    { 1, "Active", "Active user" },
                    { 2, "Blocked", "Blocked user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "created_date", "login", "password", "user_group_id", "user_state_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2009, 6, 15, 13, 45, 30, 0, DateTimeKind.Utc), "Capybara", "123456", 1, 1 },
                    { 2, new DateTime(2009, 6, 15, 13, 45, 30, 0, DateTimeKind.Utc), "Elephant", "123456", 1, 1 },
                    { 3, new DateTime(2009, 6, 15, 13, 45, 30, 0, DateTimeKind.Utc), "Monkey", "123456", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_Groups_id",
                table: "user_Groups",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_States_id",
                table: "user_States",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_id",
                table: "Users",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_group_id",
                table: "Users",
                column: "user_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_state_id",
                table: "Users",
                column: "user_state_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "user_Groups");

            migrationBuilder.DropTable(
                name: "user_States");
        }
    }
}
