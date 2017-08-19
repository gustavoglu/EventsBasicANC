using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class PagamentoRepository : Repository<Pagamento>, IPagamentoRepository
    {
        public PagamentoRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
        }
    }
}
