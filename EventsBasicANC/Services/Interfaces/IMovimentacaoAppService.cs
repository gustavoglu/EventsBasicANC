using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IMovimentacaoAppService
    {
        MovimentacaoViewModel Criar(MovimentacaoViewModel entity);

       IEnumerable<MovimentacaoViewModel> Criar(ICollection<MovimentacaoViewModel> entitys);

        MovimentacaoViewModel Atualizar(MovimentacaoViewModel entity);

        MovimentacaoViewModel Deletar(Guid id);

        MovimentacaoViewModel TrazerPorId(Guid id);

        MovimentacaoViewModel TrazerAtivoPorId(Guid id);

        MovimentacaoViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<MovimentacaoViewModel> TrazerTodosDeletadosPorEvento(Guid id_evento);

        IEnumerable<MovimentacaoViewModel> TrazerTodosPorEvento(Guid id_evento);

        IEnumerable<MovimentacaoViewModel> TrazerTodosAtivosPorEvento(Guid id_evento);

        IEnumerable<MovimentacaoViewModel> TrazerTodos();

        IEnumerable<MovimentacaoViewModel> TrazerTodosAtivos();

        IEnumerable<MovimentacaoViewModel> TrazerTodosDeletados();
    }
}
