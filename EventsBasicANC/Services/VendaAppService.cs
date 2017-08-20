﻿using AutoMapper;
using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsBasicANC.Services
{
    public class VendaAppService : IVendaAppService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;
        public VendaAppService(IVendaRepository vendaRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        public VendaViewModel Atualizar(VendaViewModel VendaViewModel)
        {
            var model = _mapper.Map<Venda>(VendaViewModel);
            var modelAtualizado = _mapper.Map(VendaViewModel, model);
            return _mapper.Map<VendaViewModel>(_vendaRepository.Atualizar(modelAtualizado));
        }

        public VendaViewModel Criar(VendaViewModel VendaViewModel)
        {
            var model = _mapper.Map<Venda>(VendaViewModel);
            return _mapper.Map<VendaViewModel>(_vendaRepository.Criar(model));
        }

        public IEnumerable<VendaViewModel> Criar(ICollection<VendaViewModel> vendasViewModel)
        {
            var modelList = _mapper.Map<ICollection<Venda>>(vendasViewModel.ToList());
            return _mapper.Map<IEnumerable<VendaViewModel>>(_vendaRepository.Criar(modelList));
        }

        public VendaViewModel Deletar(Guid id)
        {
            return _mapper.Map<VendaViewModel>(_vendaRepository.Deletar(id));
        }

        public VendaViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<VendaViewModel>(_vendaRepository.TrazerAtivoPorId(id));
        }

        public VendaViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<VendaViewModel>(_vendaRepository.TrazerDeletadoPorId(id));
        }

        public VendaViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<VendaViewModel>(_vendaRepository.TrazerPorId(id));
        }

        public IEnumerable<VendaViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<VendaViewModel>>(_vendaRepository.TrazerTodos().ToList());
        }

        public IEnumerable<VendaViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<VendaViewModel>>(_vendaRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<VendaViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<VendaViewModel>>(_vendaRepository.TrazerTodosDeletados().ToList());
        }
    }
}