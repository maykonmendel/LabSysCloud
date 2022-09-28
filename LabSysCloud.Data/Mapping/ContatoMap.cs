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
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> contato)
        {
            contato.HasOne<Paciente>(e => e.Paciente)
                .WithOne(p => p.Contato)
                .HasForeignKey<Paciente>(p => p.ContatoId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}