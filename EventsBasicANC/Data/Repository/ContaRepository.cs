using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
        }
    }
}
