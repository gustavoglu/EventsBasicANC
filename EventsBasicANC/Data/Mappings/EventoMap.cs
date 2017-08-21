using EventsBasicANC.Data.Extensions;
using EventsBasicANC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBasicANC.Data.Mappings
{
    public class EventoMap : EntityTypeConfiguration<Evento>
    {
        public override void Map(EntityTypeBuilder<Evento> evento)
        {
            evento.HasKey(e => e.Id);

            evento.HasOne(e => e.Organizador)
                .WithMany(o => o.Eventos)
                .HasForeignKey(e => e.Id_organizador)
                .IsRequired();

            evento.HasMany(e => e.Contratos)
                .WithOne(c => c.Evento)
                .HasForeignKey(c => c.Id_evento)
                .OnDelete( Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

        }
    }
}
