using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class CorRepository : Repository<Cor>, ICorRepository
    {
        public CorRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
        }
    }
}
