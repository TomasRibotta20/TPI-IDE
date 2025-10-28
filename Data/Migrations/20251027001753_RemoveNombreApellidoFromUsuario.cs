using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNombreApellidoFromUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Verificar si las columnas existen antes de eliminarlas
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND name = 'Apellido')
                BEGIN
                    ALTER TABLE [Usuarios] DROP COLUMN [Apellido]
                END
            ");

            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND name = 'Nombre')
                BEGIN
                    ALTER TABLE [Usuarios] DROP COLUMN [Nombre]
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
