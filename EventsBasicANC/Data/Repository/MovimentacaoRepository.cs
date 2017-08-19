using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class MovimentacaoRepository : Repository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
        }
    }
}
