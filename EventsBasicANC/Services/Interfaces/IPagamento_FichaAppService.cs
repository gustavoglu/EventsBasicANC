using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IPagamento_FichaAppService
    {
        Pagamento_FichaViewModel Criar(Pagamento_FichaViewModel entity);

        IEnumerable<Pagamento_FichaViewModel> Criar(ICollection<Pagamento_FichaViewModel> entitys);

        Pagamento_FichaViewModel Atualizar(Pagamento_FichaViewModel entity);

        Pagamento_FichaViewModel Deletar(Guid id);

        Pagamento_FichaViewModel TrazerPorId(Guid id);

        Pagamento_FichaViewModel TrazerAtivoPorId(Guid id);

        Pagamento_FichaViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<Pagamento_FichaViewModel> TrazerTodos();

        IEnumerable<Pagamento_FichaViewModel> TrazerTodosAtivos();

        IEnumerable<Pagamento_FichaViewModel> TrazerTodosDeletados();
    }
}
