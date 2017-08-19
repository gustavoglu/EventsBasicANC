using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
        }
    }
}
