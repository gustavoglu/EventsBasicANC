using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IContratoAppService
    {
        ContratoViewModel Criar(ContratoViewModel entity);

        IEnumerable<ContratoViewModel> Criar(ICollection<ContratoViewModel> entitys);

        ContratoViewModel Atualizar(ContratoViewModel entity);

        ContratoViewModel Deletar(Guid id);

        ContratoViewModel TrazerPorId(Guid id);

        ContratoViewModel TrazerAtivoPorId(Guid id);

        ContratoViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<ContratoViewModel> TrazerTodos();

        IEnumerable<ContratoViewModel> TrazerTodosAtivos();

        IEnumerable<ContratoViewModel> TrazerTodosDeletados();

    }
}
