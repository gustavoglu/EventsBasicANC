using AutoMapper;
using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsBasicANC.Services
{
    public class Pagamento_FichaAppService : IPagamento_FichaAppService
    {
        private readonly IPagamento_FichaRepository _pagamento_FichaRepository;
        private readonly IMapper _mapper;
        public Pagamento_FichaAppService(IPagamento_FichaRepository pagamento_FichaRepository, IMapper mapper)
        {
            _pagamento_FichaRepository = pagamento_FichaRepository;
            _mapper = mapper;
        }

        public Pagamento_FichaViewModel Atualizar(Pagamento_FichaViewModel Pagamento_FichaViewModel)
        {
            var model = _mapper.Map<Pagamento_Ficha>(Pagamento_FichaViewModel);
            var modelAtualizado = _mapper.Map(Pagamento_FichaViewModel, model);
            return _mapper.Map<Pagamento_FichaViewModel>(_pagamento_FichaRepository.Atualizar(modelAtualizado));
        }

        public Pagamento_FichaViewModel Criar(Pagamento_FichaViewModel Pagamento_FichaViewModel)
        {
            var model = _mapper.Map<Pagamento_Ficha>(Pagamento_FichaViewModel);
            return _mapper.Map<Pagamento_FichaViewModel>(_pagamento_FichaRepository.Criar(model));
        }

        public IEnumerable<Pagamento_FichaViewModel> Criar(ICollection<Pagamento_FichaViewModel> pagamentos_fichaViewModel)
        {
            var modelList = _mapper.Map<ICollection<Pagamento_Ficha>>(pagamentos_fichaViewModel.ToList());
            return _mapper.Map<IEnumerable<Pagamento_FichaViewModel>>(_pagamento_FichaRepository.Criar(modelList));
        }

        public Pagamento_FichaViewModel Deletar(Guid id)
        {
            return _mapper.Map<Pagamento_FichaViewModel>(_pagamento_FichaRepository.Deletar(id));
        }

        public Pagamento_FichaViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<Pagamento_FichaViewModel>(_pagamento_FichaRepository.TrazerAtivoPorId(id));
        }

        public Pagamento_FichaViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<Pagamento_FichaViewModel>(_pagamento_FichaRepository.TrazerDeletadoPorId(id));
        }

        public Pagamento_FichaViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<Pagamento_FichaViewModel>(_pagamento_FichaRepository.TrazerPorId(id));
        }

        public IEnumerable<Pagamento_FichaViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<Pagamento_FichaViewModel>>(_pagamento_FichaRepository.TrazerTodos().ToList());
        }

        public IEnumerable<Pagamento_FichaViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<Pagamento_FichaViewModel>>(_pagamento_FichaRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<Pagamento_FichaViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<Pagamento_FichaViewModel>>(_pagamento_FichaRepository.TrazerTodosDeletados().ToList());
        }
    }
}
