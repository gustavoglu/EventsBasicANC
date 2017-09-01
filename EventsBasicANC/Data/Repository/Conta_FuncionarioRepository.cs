using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsBasicANC.Data.Repository
{
    public class Conta_FuncionarioRepository : Repository<Conta_Funcionario>, IConta_FuncionarioRepository
    {
        public Conta_FuncionarioRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {

        }

        public virtual IEnumerable<Conta_Funcionario> TrazerPorContaPrincipal(Guid id_conta_principal)
        {
            return this.DbSet.Where(cf => cf.Id_conta == id_conta_principal && cf.Deletado == false);
        }

        public virtual IEnumerable<Conta_Funcionario> TrazerPorFuncionario(Guid id_conta_funcionario)
        {
            return this.DbSet.Where(cf => cf.Id_funcionario == id_conta_funcionario && cf.Deletado == false);
        }
    }
}
