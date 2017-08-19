using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class Conta_FuncionarioRepository : Repository<Conta_Funcionario>, IConta_FuncionarioRepository
    {
        public Conta_FuncionarioRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
        }
    }
}
