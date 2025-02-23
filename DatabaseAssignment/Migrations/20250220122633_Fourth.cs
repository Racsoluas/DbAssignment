using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseAssignment.Migrations
{
    /// <inheritdoc />
    public partial class Fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProductEntity_ProductId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_StatusTypes_StatusId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductEntity",
                table: "ProductEntity");

            migrationBuilder.RenameTable(
                name: "ProductEntity",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Projects",
                newName: "ProjectManagerId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Projects",
                newName: "ProjectName");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Projects",
                newName: "ArticleId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Projects",
                newName: "Notes");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                newName: "IX_Projects_ProjectManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProductId",
                table: "Projects",
                newName: "IX_Projects_ArticleId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ActivityStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(type: "char(3)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencySymbol = table.Column<string>(type: "char(3)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyCode);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyId = table.Column<string>(type: "char(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CurrencyId",
                table: "Articles",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ActivityStatuses_StatusId",
                table: "Projects",
                column: "StatusId",
                principalTable: "ActivityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Articles_ArticleId",
                table: "Projects",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ActivityStatuses_StatusId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Articles_ArticleId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_ProjectManagerId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ActivityStatuses");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ProductEntity");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "Projects",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ProjectManagerId",
                table: "Projects",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Projects",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "Projects",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                newName: "IX_Projects_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ArticleId",
                table: "Projects",
                newName: "IX_Projects_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductEntity",
                table: "ProductEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProductEntity_ProductId",
                table: "Projects",
                column: "ProductId",
                principalTable: "ProductEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_StatusTypes_StatusId",
                table: "Projects",
                column: "StatusId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
