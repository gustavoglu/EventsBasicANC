using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IContatoAppService
    {
        ContatoViewModel Criar(ContatoViewModel entity);

       IEnumerable<ContatoViewModel> Criar(ICollection<ContatoViewModel> entitys);

        ContatoViewModel Atualizar(ContatoViewModel entity);

        ContatoViewModel Deletar(Guid id);

        ContatoViewModel TrazerPorId(Guid id);

        ContatoViewModel TrazerAtivoPorId(Guid id);

        ContatoViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<ContatoViewModel> TrazerTodos();

        IEnumerable<ContatoViewModel> TrazerTodosAtivos();

        IEnumerable<ContatoViewModel> TrazerTodosDeletados();

    }
}
