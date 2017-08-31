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

        FichaViewModel Atualizar(FichaViewModel entity, Guid id_pagamento,bool estorno = false, string movimentacaoObs = null);

        FichaViewModel Deletar(Guid id);

        FichaViewModel TrazerPorId(Guid id);

        FichaViewModel TrazerAtivoPorId(Guid id);

        FichaViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<FichaViewModel> TrazerTodos();

        IEnumerable<FichaViewModel> TrazerTodosAtivos();

        IEnumerable<FichaViewModel> TrazerTodosDeletados();

        IEnumerable<FichaViewModel> EfetuaPagamentoFichas(ICollection<FichaViewModel> fichas, Guid id_pagamento, double totalVenda);

        IEnumerable<FichaViewModel> CriaFichasParaNovoEvento(Guid id_evento);
    }
}
