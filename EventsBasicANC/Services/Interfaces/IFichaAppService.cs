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

        FichaViewModel Atualizar(FichaViewModel entity, Guid? id_pagamento,bool estorno = false, string movimentacaoObs = null);

        FichaViewModel Deletar(Guid id);

        FichaViewModel TrazerPorCodigo(string codigo,Guid id_evento);

        FichaViewModel TrazerPorId(Guid id, Guid? id_evento = null);

        FichaViewModel TrazerAtivoPorId(Guid id, Guid? id_evento = null);

        FichaViewModel TrazerDeletadoPorId(Guid id,Guid? id_evento = null);

        IEnumerable<FichaViewModel> TrazerTodos(Guid? id_evento = null);

        IEnumerable<FichaViewModel> TrazerTodosAtivos(Guid? id_evento = null);

        IEnumerable<FichaViewModel> TrazerTodosDeletados(Guid? id_evento = null);

        IEnumerable<FichaViewModel> EfetuaPagamentoFichas(ICollection<FichaViewModel> fichas, Guid id_pagamento, double totalVenda);

        IEnumerable<FichaViewModel> CriaFichasParaNovoEvento(Guid id_evento, int qtdFichas);

        IEnumerable<FichaViewModel> Estorno(Guid id_pagamento);

        IEnumerable<FichaViewModel> TrazerPorEvento(Guid id_evento);

        FichaViewModel Estorno(Guid id_ficha,double valor);

        bool ValidaCodigoDaFicha(string codigo);

        bool CodigoFichaExist(string codigo, Guid id_evento);
    }
}
