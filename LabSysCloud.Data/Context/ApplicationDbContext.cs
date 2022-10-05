using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LabSysCloud.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>()
                .HasOne<Endereco>(p => p.Endereco)
                .WithOne(e => e.Paciente)
                .HasForeignKey<Endereco>(e => e.PacienteId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            modelBuilder.Entity<Paciente>()
                .HasOne<Contato>(p => p.Contato)
                .WithOne(c => c.Paciente)
                .HasForeignKey<Contato>(c => c.PacienteId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            modelBuilder.Entity<Endereco>()
                .HasOne<Paciente>(e => e.Paciente)
                .WithOne(p => p.Endereco)
                .HasForeignKey<Paciente>(p => p.EnderecoId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            modelBuilder.Entity<Contato>()
                .HasOne<Paciente>(e => e.Paciente)
                .WithOne(p => p.Contato)
                .HasForeignKey<Paciente>(p => p.ContatoId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}