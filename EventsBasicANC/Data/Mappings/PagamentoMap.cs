using EventsBasicANC.Data.Extensions;
using EventsBasicANC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBasicANC.Data.Mappings
{
    public class PagamentoMap : EntityTypeConfiguration<Pagamento>
    {
        public override void Map(EntityTypeBuilder<Pagamento> pagamento)
        {
            pagamento.HasKey(p => p.Id);

            pagamento.HasOne(p => p.Venda)
                .WithOne(v => v.Pagamento)
                .HasForeignKey<Pagamento>(p => p.Id)
                .IsRequired();

        }
    }
}
