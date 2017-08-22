using EventsBasicANC.Data.Extensions;
using EventsBasicANC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBasicANC.Data.Mappings
{
    public class ContaMap : EntityTypeConfiguration<Conta>
    {
        public override void Map(EntityTypeBuilder<Conta> conta)
        {
            conta.HasKey(c => c.Id);

            conta.HasOne(c => c.Conta_Principal)
                .WithOne()
                .HasForeignKey<Conta>(c => c.Id_Conta_Principal)
                .IsRequired(false)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
