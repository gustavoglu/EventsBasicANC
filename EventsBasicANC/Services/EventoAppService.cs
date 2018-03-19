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
    public class EventoAppService : IEventoAppService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IFichaAppService _fichaAppService;
        private readonly IContratoRepository _contratoRepository;
        private readonly IMapper _mapper;
        public EventoAppService(IEventoRepository eventoRepository, IFichaAppService fichaAppService, IContratoRepository contratoRepository, IMapper mapper)
        {
            _fichaAppService = fichaAppService;
            _eventoRepository = eventoRepository;
            _contratoRepository = contratoRepository;
            _mapper = mapper;
        }

        public EventoViewModel Atualizar(EventoViewModel EventoViewModel)
        {
            var model = _mapper.Map<Evento>(EventoViewModel);
            var modelAtualizado = _mapper.Map(EventoViewModel, model);
            return _mapper.Map<EventoViewModel>(_eventoRepository.Atualizar(modelAtualizado));
        }

        public EventoViewModel Criar(EventoViewModel EventoViewModel, int qtdFichas = 0)
        {
            var model = _mapper.Map<Evento>(EventoViewModel);
            var eventoCriado = _mapper.Map<EventoViewModel>(_eventoRepository.Criar(model));
            var fichasCriadas = _fichaAppService.CriaFichasParaNovoEvento(eventoCriado.Id.Value, qtdFichas);
            return eventoCriado;
        }

        public IEnumerable<EventoViewModel> Criar(ICollection<EventoViewModel> contasViewModel)
        {
            var modelList = _mapper.Map<ICollection<Evento>>(contasViewModel.ToList());
            return _mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.Criar(modelList));
        }

        public EventoViewModel Deletar(Guid id)
        {
            return _mapper.Map<EventoViewModel>(_eventoRepository.Deletar(id));
        }


        public EventoViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<EventoViewModel>(_eventoRepository.TrazerAtivoPorId(id));
        }

        public EventoViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<EventoViewModel>(_eventoRepository.TrazerDeletadoPorId(id));
        }

        public EventoViewModel TrazerEventoFirstPorLoja(Guid id_loja)
        {
            var contrato = _contratoRepository.PesquisarAtivos(c => c.Id_loja == id_loja).FirstOrDefault();
            if (contrato == null) return null;
            return this.TrazerPorId(contrato.Id_evento);
        }

        public EventoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<EventoViewModel>(_eventoRepository.TrazerPorId(id));
        }

        public IEnumerable<EventoViewModel> TrazerPorLoja(Guid id_loja)
        {
            var eventos = _contratoRepository.PesquisarAtivos(c => c.Id_loja == id_loja).ToList().Select(c => c.Evento);
            return _mapper.Map<IEnumerable<EventoViewModel>>(eventos);
        }

        public IEnumerable<EventoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.TrazerTodos().ToList());
        }

        public IEnumerable<EventoViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<EventoViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.TrazerTodosDeletados().ToList());
        }
    }
}
