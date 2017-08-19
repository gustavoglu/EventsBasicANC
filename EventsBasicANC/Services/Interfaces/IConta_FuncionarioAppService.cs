using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IConta_FuncionarioAppService
    {
        Conta_FuncionarioViewModel Criar(Conta_FuncionarioViewModel conta_FuncionarioViewModel);

        IEnumerable<Conta_FuncionarioViewModel> Criar(ICollection<Conta_FuncionarioViewModel> conta_FuncionarioViewModel);

        Conta_FuncionarioViewModel Atualizar(Conta_FuncionarioViewModel conta_FuncionarioViewModel);

        Conta_FuncionarioViewModel Deletar(Guid Id);

        Conta_FuncionarioViewModel TrazerPorId(Guid id);

        Conta_FuncionarioViewModel TrazerAtivoPorId(Guid id);

        Conta_FuncionarioViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<Conta_FuncionarioViewModel> TrazerTodos();

        IEnumerable<Conta_FuncionarioViewModel> TrazerTodosAtivos();

        IEnumerable<Conta_FuncionarioViewModel> TrazerTodosDeletados();

    }
}
