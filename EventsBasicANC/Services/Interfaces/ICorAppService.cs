using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Services.Interfaces
{
    public interface ICorAppService
    {
        CorViewModel Criar(CorViewModel entity);

        CorViewModel Criar(ICollection<CorViewModel> entitys);

        CorViewModel Atualizar(CorViewModel entity);

        CorViewModel Deletar(Guid id);

        CorViewModel TrazerPorId(Guid id);

        CorViewModel TrazerAtivoPorId(Guid id);

        CorViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<CorViewModel> TrazerTodos();

        IEnumerable<CorViewModel> TrazerTodosAtivos();

        IEnumerable<CorViewModel> TrazerTodosDeletados();

    }
}
