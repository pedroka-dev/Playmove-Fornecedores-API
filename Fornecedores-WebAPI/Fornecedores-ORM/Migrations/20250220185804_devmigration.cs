using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fornecedores_ORM.Migrations
{
    /// <inheritdoc />
    public partial class devmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBFORNECEDOR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFORNECEDOR", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TBFORNECEDOR",
                columns: new[] { "Id", "Email", "Nome" },
                values: new object[,]
                {
                    { 1, "joao.silva@email.com", "João Silva" },
                    { 2, "maria.oliveira@email.com", "Maria Oliveira" },
                    { 3, "carlos.santos@email.com", "Carlos Santos" },
                    { 4, "ana.souza@email.com", "Ana Souza" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBFORNECEDOR");
        }
    }
}
