using EventsBasicANC.Data.Extensions;
using EventsBasicANC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBasicANC.Data.Mappings
{
    public class VendaMap : EntityTypeConfiguration<Venda>
    {
        public override void Map(EntityTypeBuilder<Venda> venda)
        {
            venda.HasKey(v => v.Id);

            venda.HasOne(v => v.Evento)
                .WithMany(e => e.Vendas)
                .HasForeignKey(v => v.Id_Evento)
                .IsRequired();

            venda.HasOne(v => v.Conta)
                .WithMany(c => c.Vendas)
                .HasForeignKey(v => v.Id_loja)
                .IsRequired();

        }
    }
}
