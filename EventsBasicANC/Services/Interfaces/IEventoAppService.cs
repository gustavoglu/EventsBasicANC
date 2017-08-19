using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IEventoAppService
    {
        EventoViewModel Criar(EventoViewModel entity);

        EventoViewModel Criar(ICollection<EventoViewModel> entitys);

        EventoViewModel Atualizar(EventoViewModel entity);

        EventoViewModel Deletar(Guid id);

        EventoViewModel TrazerPorId(Guid id);

        EventoViewModel TrazerAtivoPorId(Guid id);

        EventoViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<EventoViewModel> TrazerTodos();

        IEnumerable<EventoViewModel> TrazerTodosAtivos();

        IEnumerable<EventoViewModel> TrazerTodosDeletados();
    }
}
