using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IVenda_ProdutoAppService
    {
        Venda_ProdutoViewModel Criar(Venda_ProdutoViewModel entity);

        IEnumerable<Venda_ProdutoViewModel> Criar(ICollection<Venda_ProdutoViewModel> entitys);

        Venda_ProdutoViewModel Atualizar(Venda_ProdutoViewModel entity);

        Venda_ProdutoViewModel Deletar(Guid id);

        Venda_ProdutoViewModel TrazerPorId(Guid id);

        Venda_ProdutoViewModel TrazerAtivoPorId(Guid id);

        Venda_ProdutoViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<Venda_ProdutoViewModel> TrazerTodos();

        IEnumerable<Venda_ProdutoViewModel> TrazerTodosAtivos();

        IEnumerable<Venda_ProdutoViewModel> TrazerTodosDeletados();

    }
}
