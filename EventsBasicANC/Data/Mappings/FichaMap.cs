﻿using EventsBasicANC.Data.Extensions;
using EventsBasicANC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBasicANC.Data.Mappings
{
    public class FichaMap : EntityTypeConfiguration<Ficha>
    {
        public override void Map(EntityTypeBuilder<Ficha> ficha)
        {
            ficha.HasKey(f => f.Id);

            ficha.HasOne(f => f.Evento)
                .WithMany(e => e.Fichas)
                .HasForeignKey(f => f.Id_evento)
                .IsRequired();
        }
    }
}
