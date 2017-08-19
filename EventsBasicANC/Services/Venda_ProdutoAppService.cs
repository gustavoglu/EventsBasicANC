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
    public class Venda_ProdutoAppService : IVenda_ProdutoAppService
    {
        private readonly IVenda_ProdutoRepository _venda_ProdutoRepository;
        private readonly IMapper _mapper;
        public Venda_ProdutoAppService(IVenda_ProdutoRepository venda_ProdutoRepository, IMapper mapper)
        {
            _venda_ProdutoRepository = venda_ProdutoRepository;
            _mapper = mapper;
        }

        public Venda_ProdutoViewModel Atualizar(Venda_ProdutoViewModel Venda_ProdutoViewModel)
        {
            var model = _mapper.Map<Venda_Produto>(Venda_ProdutoViewModel);
            var modelAtualizado = _mapper.Map(Venda_ProdutoViewModel, model);
            return _mapper.Map<Venda_ProdutoViewModel>(_venda_ProdutoRepository.Atualizar(modelAtualizado));
        }

        public Venda_ProdutoViewModel Criar(Venda_ProdutoViewModel Venda_ProdutoViewModel)
        {
            var model = _mapper.Map<Venda_Produto>(Venda_ProdutoViewModel);
            return _mapper.Map<Venda_ProdutoViewModel>(_venda_ProdutoRepository.Criar(model));
        }

        public IEnumerable<Venda_ProdutoViewModel> Criar(ICollection<Venda_ProdutoViewModel> vendas_ProdutoViewModel)
        {
            var modelList = _mapper.Map<ICollection<Venda_Produto>>(vendas_ProdutoViewModel.ToList());
            return _mapper.Map<IEnumerable<Venda_ProdutoViewModel>>(_venda_ProdutoRepository.Criar(modelList));
        }

        public Venda_ProdutoViewModel Deletar(Guid id)
        {
            return _mapper.Map<Venda_ProdutoViewModel>(_venda_ProdutoRepository.Deletar(id));
        }

        public Venda_ProdutoViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<Venda_ProdutoViewModel>(_venda_ProdutoRepository.TrazerAtivoPorId(id));
        }

        public Venda_ProdutoViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<Venda_ProdutoViewModel>(_venda_ProdutoRepository.TrazerDeletadoPorId(id));
        }

        public Venda_ProdutoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<Venda_ProdutoViewModel>(_venda_ProdutoRepository.TrazerPorId(id));
        }

        public IEnumerable<Venda_ProdutoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<Venda_ProdutoViewModel>>(_venda_ProdutoRepository.TrazerTodos().ToList());
        }

        public IEnumerable<Venda_ProdutoViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<Venda_ProdutoViewModel>>(_venda_ProdutoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<Venda_ProdutoViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<Venda_ProdutoViewModel>>(_venda_ProdutoRepository.TrazerTodosDeletados().ToList());
        }
    }
}
