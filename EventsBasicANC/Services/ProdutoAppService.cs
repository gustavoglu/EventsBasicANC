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
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public ProdutoAppService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public ProdutoViewModel Atualizar(ProdutoViewModel ProdutoViewModel)
        {
            var model = _mapper.Map<Produto>(ProdutoViewModel);
            var modelAtualizado = _mapper.Map(ProdutoViewModel, model);
            return _mapper.Map<ProdutoViewModel>(_produtoRepository.Atualizar(modelAtualizado));
        }

        public ProdutoViewModel Criar(ProdutoViewModel ProdutoViewModel)
        {
            var model = _mapper.Map<Produto>(ProdutoViewModel);
            return _mapper.Map<ProdutoViewModel>(_produtoRepository.Criar(model));
        }

        public IEnumerable<ProdutoViewModel> Criar(ICollection<ProdutoViewModel> produtosViewModel)
        {
            var modelList = _mapper.Map<ICollection<Produto>>(produtosViewModel.ToList());
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.Criar(modelList));
        }

        public ProdutoViewModel Deletar(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(_produtoRepository.Deletar(id));
        }

        public ProdutoViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(_produtoRepository.TrazerAtivoPorId(id));
        }

        public ProdutoViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(_produtoRepository.TrazerDeletadoPorId(id));
        }

        public ProdutoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(_produtoRepository.TrazerPorId(id));
        }

        public IEnumerable<ProdutoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.TrazerTodos().ToList());
        }

        public IEnumerable<ProdutoViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<ProdutoViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.TrazerTodosDeletados().ToList());
        }
    }
}
