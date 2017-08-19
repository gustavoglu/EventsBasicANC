using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IEnderecoAppService
    {
        EnderecoViewModel Criar(EnderecoViewModel entity);

       IEnumerable <EnderecoViewModel> Criar(ICollection<EnderecoViewModel> entitys);

        EnderecoViewModel Atualizar(EnderecoViewModel entity);

        EnderecoViewModel Deletar(Guid id);

        EnderecoViewModel TrazerPorId(Guid id);

        EnderecoViewModel TrazerAtivoPorId(Guid id);

        EnderecoViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<EnderecoViewModel> TrazerTodos();

        IEnumerable<EnderecoViewModel> TrazerTodosAtivos();

        IEnumerable<EnderecoViewModel> TrazerTodosDeletados();

    }
}
