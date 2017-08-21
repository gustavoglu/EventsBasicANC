using EventsBasicANC.Data.Extensions;
using EventsBasicANC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBasicANC.Data.Mappings
{
    public class CorMap : EntityTypeConfiguration<Cor>
    {
        public override void Map(EntityTypeBuilder<Cor> cor)
        {
            cor.HasMany(c => c.Produtos)
                .WithOne(p => p.Cor)
                .HasForeignKey(c => c.Id_Cor)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
