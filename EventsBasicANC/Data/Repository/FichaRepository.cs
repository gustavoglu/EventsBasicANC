using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class FichaRepository : Repository<Ficha>, IFichaRepository
    {
        public FichaRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
        }
    }
}
