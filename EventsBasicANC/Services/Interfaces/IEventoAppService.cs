using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IEventoAppService
    {
        EventoViewModel Criar(EventoViewModel entity, int qtdFichas);

        IEnumerable<EventoViewModel> Criar(ICollection<EventoViewModel> entitys);

        EventoViewModel Atualizar(EventoViewModel entity);

        EventoViewModel Deletar(Guid id);

        EventoViewModel TrazerPorId(Guid id);

        EventoViewModel TrazerAtivoPorId(Guid id);

        EventoViewModel TrazerDeletadoPorId(Guid id);

        EventoViewModel TrazerEventoFirstPorLoja(Guid id_loja);

        IEnumerable<EventoViewModel> TrazerTodos();

        IEnumerable<EventoViewModel> TrazerTodosAtivos();

        IEnumerable<EventoViewModel> TrazerTodosDeletados();

        IEnumerable<EventoViewModel> TrazerPorLoja(Guid id_loja);

    }
}
