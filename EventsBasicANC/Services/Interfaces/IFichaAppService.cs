using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IFichaAppService
    {
        FichaViewModel Criar(FichaViewModel entity);

        IEnumerable<FichaViewModel> Criar(ICollection<FichaViewModel> entitys);

        FichaViewModel Atualizar(FichaViewModel entity);

        FichaViewModel Deletar(Guid id);

        FichaViewModel TrazerPorId(Guid id);

        FichaViewModel TrazerAtivoPorId(Guid id);

        FichaViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<FichaViewModel> TrazerTodos();

        IEnumerable<FichaViewModel> TrazerTodosAtivos();

        IEnumerable<FichaViewModel> TrazerTodosDeletados();
    }
}
