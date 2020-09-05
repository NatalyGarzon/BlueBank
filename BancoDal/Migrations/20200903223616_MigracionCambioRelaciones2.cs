using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoDal.Migrations
{
    public partial class MigracionCambioRelaciones2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_Persona_PersonaIdPersona",
                schema: "DBO",
                table: "Cuenta");

            migrationBuilder.DropIndex(
                name: "IX_Cuenta_PersonaIdPersona",
                schema: "DBO",
                table: "Cuenta");

            migrationBuilder.DropColumn(
                name: "IdPersona",
                schema: "DBO",
                table: "Cuenta");

            migrationBuilder.DropColumn(
                name: "PersonaIdPersona",
                schema: "DBO",
                table: "Cuenta");

            migrationBuilder.AddColumn<int>(
                name: "IdPersona1",
                schema: "DBO",
                table: "Cuenta",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_IdPersona1",
                schema: "DBO",
                table: "Cuenta",
                column: "IdPersona1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_Persona_IdPersona1",
                schema: "DBO",
                table: "Cuenta",
                column: "IdPersona1",
                principalSchema: "DBO",
                principalTable: "Persona",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_Persona_IdPersona1",
                schema: "DBO",
                table: "Cuenta");

            migrationBuilder.DropIndex(
                name: "IX_Cuenta_IdPersona1",
                schema: "DBO",
                table: "Cuenta");

            migrationBuilder.DropColumn(
                name: "IdPersona1",
                schema: "DBO",
                table: "Cuenta");

            migrationBuilder.AddColumn<int>(
                name: "IdPersona",
                schema: "DBO",
                table: "Cuenta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonaIdPersona",
                schema: "DBO",
                table: "Cuenta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_PersonaIdPersona",
                schema: "DBO",
                table: "Cuenta",
                column: "PersonaIdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_Persona_PersonaIdPersona",
                schema: "DBO",
                table: "Cuenta",
                column: "PersonaIdPersona",
                principalSchema: "DBO",
                principalTable: "Persona",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
