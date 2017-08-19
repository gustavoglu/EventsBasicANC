using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class Venda_ProdutoRepository : Repository<Venda_Produto>, IVenda_ProdutoRepository
    {
        public Venda_ProdutoRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
        }
    }
}
