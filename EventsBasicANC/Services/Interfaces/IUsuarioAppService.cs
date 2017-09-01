using EventsBasicANC.ViewModels;
using System;
using System.Threading.Tasks;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IUsuarioAppService
    {

        Task<UsuarioViewModel> CriarLojaPorOrganizador(NovaLojaViewModel novaLojaViewModel);

        Task<UsuarioViewModel> CriarFuncionario(NovoFuncionarioViewModel novoFuncionarioViewModel);

    }
}
