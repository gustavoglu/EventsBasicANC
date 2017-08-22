using EventsBasicANC.Data.Extensions;
using EventsBasicANC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBasicANC.Data.Mappings
{
    public class ContatoMap : EntityTypeConfiguration<Contato>
    {
        public override void Map(EntityTypeBuilder<Contato> contato)
        {
            contato.HasOne(c => c.Conta)
                .WithOne(cc => cc.Contato)
                .HasForeignKey<Conta>(c => c.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
