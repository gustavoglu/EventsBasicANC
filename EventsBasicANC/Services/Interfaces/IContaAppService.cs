using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IContaAppService
    {
        ContaViewModel Criar(ContaViewModel entity);

        ContaViewModel Criar(ICollection<ContaViewModel> entitys);

        ContaViewModel Atualizar(ContaViewModel entity);

        ContaViewModel Deletar(Guid id);

        ContaViewModel TrazerPorId(Guid id);

        ContaViewModel TrazerAtivoPorId(Guid id);

        ContaViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<ContaViewModel> TrazerTodos();

        IEnumerable<ContaViewModel> TrazerTodosAtivos();

        IEnumerable<ContaViewModel> TrazerTodosDeletados();

    }
}
