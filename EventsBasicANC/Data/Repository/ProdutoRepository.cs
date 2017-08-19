using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
        }
    }
}
