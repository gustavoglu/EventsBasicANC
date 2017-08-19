using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBasicANC.Data.Extensions
{
    public abstract class EntityTypeConfiguration<T> where T : class
    {
        public abstract void Map(EntityTypeBuilder<T> builder);
    }
}
