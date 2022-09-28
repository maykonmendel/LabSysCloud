using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Entities.ValueObjects;
using LabSysCloud.Data.Mapping;

namespace LabSysCloud.Data.Context
{
    public class LabSysCloudContext : DbContext
    {
        public LabSysCloudContext(DbContextOptions<LabSysCloudContext> options) : base(options)
        {

        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PacienteMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());

            base.OnModelCreating(modelBuilder);            
        }
    }
}