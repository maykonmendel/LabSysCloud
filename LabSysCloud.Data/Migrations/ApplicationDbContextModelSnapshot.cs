﻿// <auto-generated />
using System;
using LabSysCloud.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabSysCloud.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LabSysCloud.Domain.Entities.Paciente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("CNS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Convenio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EstadoCivil")
                        .HasColumnType("int");

                    b.Property<int?>("Etnia")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroRegistro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanoSaude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sexo")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidadeRegistro")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("LabSysCloud.Domain.Entities.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("NomeUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("LabSysCloud.Domain.Entities.Paciente", b =>
                {
                    b.OwnsOne("LabSysCloud.Domain.Entities.ValueObjects.Contato", "Contato", b1 =>
                        {
                            b1.Property<long>("PacienteId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Celular")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("TelefoneResidencial")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PacienteId");

                            b1.ToTable("Pacientes");

                            b1.WithOwner()
                                .HasForeignKey("PacienteId");
                        });

                    b.OwnsOne("LabSysCloud.Domain.Entities.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<long>("PacienteId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Bairro")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CEP")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Cidade")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Complemento")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Estado")
                                .HasColumnType("int");

                            b1.Property<string>("Logradouro")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Numero")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PacienteId");

                            b1.ToTable("Pacientes");

                            b1.WithOwner()
                                .HasForeignKey("PacienteId");
                        });

                    b.Navigation("Contato");

                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
