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
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> endereco)
        {
            endereco.HasOne<Paciente>(e => e.Paciente)
                .WithOne(p => p.Endereco)
                .HasForeignKey<Paciente>(p => p.EnderecoId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}