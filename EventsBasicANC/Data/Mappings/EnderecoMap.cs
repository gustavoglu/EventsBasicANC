using EventsBasicANC.Data.Extensions;
using EventsBasicANC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBasicANC.Data.Mappings
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public override void Map(EntityTypeBuilder<Endereco> endereco)
        {
            endereco.HasOne(e => e.Conta)
                .WithOne(c => c.Endereco)
                .HasForeignKey<Conta>(c => c.Id);
        }
    }
}
