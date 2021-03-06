﻿using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IProdutoAppService
    {
        ProdutoViewModel Criar(ProdutoViewModel entity);

        IEnumerable<ProdutoViewModel> Criar(ICollection<ProdutoViewModel> entitys);

        ProdutoViewModel Atualizar(ProdutoViewModel entity);

        ProdutoViewModel Deletar(Guid id);

        ProdutoViewModel TrazerPorId(Guid id);

        ProdutoViewModel TrazerAtivoPorId(Guid id);

        ProdutoViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<ProdutoViewModel> TrazerDeletadoPorLoja(Guid id_loja);

        IEnumerable<ProdutoViewModel> TrazerAtivoPorLoja(Guid id_loja);

        IEnumerable<ProdutoViewModel> TrazerPorLoja(Guid id_loja);

        IEnumerable<ProdutoViewModel> TrazerTodos();

        IEnumerable<ProdutoViewModel> TrazerTodosAtivos();

        IEnumerable<ProdutoViewModel> TrazerTodosDeletados();

    }
}
