using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabSysCloud.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Etnia = table.Column<int>(type: "int", nullable: false),
                    EstadoCivil = table.Column<int>(type: "int", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Convenio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanoSaude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroRegistro = table.Column<int>(type: "int", nullable: false),
                    ValidadeRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contato_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contato_DDDResidencial = table.Column<int>(type: "int", nullable: true),
                    Contato_TelefoneResidencial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contato_DDDCelular = table.Column<int>(type: "int", nullable: true),
                    Contato_Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
