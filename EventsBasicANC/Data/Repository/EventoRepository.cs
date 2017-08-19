using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
        }
    }
}
