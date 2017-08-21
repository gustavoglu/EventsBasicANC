using EventsBasicANC.Data.Extensions;
using EventsBasicANC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBasicANC.Data.Mappings
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public override void Map(EntityTypeBuilder<Produto> produto)
        {

            produto.HasKey(p => p.Id);

            produto.HasOne(p => p.Loja)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.Id_loja)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
