using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabSysCloud.Data.Mapping
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> paciente)
        {
            paciente.HasOne<Endereco>(p => p.Endereco)
                .WithOne(e => e.Paciente)
                .HasForeignKey<Endereco>(e => e.PacienteId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            paciente.HasOne<Contato>(p => p.Contato)
                .WithOne(c => c.Paciente)
                .HasForeignKey<Contato>(c => c.PacienteId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}