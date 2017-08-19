using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class Pagamento_FichaRepository : Repository<Pagamento_Ficha>, IPagamento_FichaRepository
    {
        public Pagamento_FichaRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
        }
    }
}
