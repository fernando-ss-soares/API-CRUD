using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taskify.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaDeTasks2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Concluido",
                table: "Tasks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concluido",
                table: "Tasks");
        }
    }
}
