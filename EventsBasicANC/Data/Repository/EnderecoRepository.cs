using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
        }
    }
}
