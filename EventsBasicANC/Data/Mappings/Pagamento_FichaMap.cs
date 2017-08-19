using EventsBasicANC.Data.Extensions;
using EventsBasicANC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBasicANC.Data.Mappings
{
    public class Pagamento_FichaMap : EntityTypeConfiguration<Pagamento_Ficha>
    {
        public override void Map(EntityTypeBuilder<Pagamento_Ficha> pagamento_ficha)
        {
            pagamento_ficha.HasKey(pf => pf.Id);

            pagamento_ficha.HasOne(pf => pf.Ficha)
                .WithMany(f => f.Pagamento_Fichas)
                .HasForeignKey(pf => pf.Id_ficha);

        }
    }
}
