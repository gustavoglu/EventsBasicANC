using EventsBasicANC.Data;
using EventsBasicANC.Models;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Data.Repository.Interfaces
{
    public interface IConta_FuncionarioRepository : IRepository<Conta_Funcionario>
    {
        IEnumerable<Conta_Funcionario> TrazerPorContaPrincipal(Guid id_conta_principal);

        IEnumerable<Conta_Funcionario> TrazerPorFuncionario(Guid id_conta_funcionario);
    }
}
