using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class ContratoRepository : Repository<Contrato>, IContratoRepository
    {
        public ContratoRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
        }
    }
}
