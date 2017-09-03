using EventsBasicANC.Domain.Models.Enums;
using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IContaAppService
    {
        ContaViewModel Criar(ContaViewModel entity);

        IEnumerable<ContaViewModel> Criar(ICollection<ContaViewModel> entitys);

        ContaViewModel Atualizar(ContaViewModel entity);

        ContaViewModel AtualizarFuncionario(AtualizaFuncionarioViewModel atualizaFuncionarioaViewModel);

        ContaViewModel AtualizarLoja(AtualizarLojaViewModel atualizaLojaViewModel);

        ContaViewModel Deletar(Guid id);

        ContaViewModel TrazerPorId(Guid id);

        ContaViewModel TrazerAtivoPorId(Guid id);

        ContaViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<ContaViewModel> TrazerFuncionariosAtivos(Guid id_conta);

        IEnumerable<ContaViewModel> TrazerLojasAtivasPorOrganizador(Guid id_loja, Guid id_organizador);

        IEnumerable<ContaViewModel> TrazerTodos();

        IEnumerable<ContaViewModel> TrazerTodosAtivos();

        IEnumerable<ContaViewModel> TrazerTodosDeletados();

        ContaTipo? TrazerTipoDaConta(Guid id_conta);

        ContaTipo? TrazerTipoFuncionario(Guid id_conta);
    }
}
