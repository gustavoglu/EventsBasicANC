using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IPagamentoAppService
    {
        PagamentoViewModel Criar(PagamentoViewModel entity);

        PagamentoViewModel Criar(ICollection<PagamentoViewModel> entitys);

        PagamentoViewModel Atualizar(PagamentoViewModel entity);

        PagamentoViewModel Deletar(Guid id);

        PagamentoViewModel TrazerPorId(Guid id);

        PagamentoViewModel TrazerAtivoPorId(Guid id);

        PagamentoViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<PagamentoViewModel> TrazerTodos();

        IEnumerable<PagamentoViewModel> TrazerTodosAtivos();

        IEnumerable<PagamentoViewModel> TrazerTodosDeletados();
    }
}
