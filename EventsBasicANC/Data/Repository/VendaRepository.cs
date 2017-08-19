using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
        }
    }
}
