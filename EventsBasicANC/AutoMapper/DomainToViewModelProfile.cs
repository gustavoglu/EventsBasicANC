using AutoMapper;
using EventsBasicANC.Models;
using EventsBasicANC.ViewModels;

namespace EventsBasicANC.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Conta, ContaViewModel>();
            CreateMap<Contato, ContatoViewModel>();
            CreateMap<Conta_Funcionario, Conta_FuncionarioViewModel>();
            CreateMap<Contrato, ContratoViewModel>();
            CreateMap<Cor, CorViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Evento, EventoViewModel>();
            CreateMap<Ficha, FichaViewModel>();
            CreateMap<Movimentacao, MovimentacaoViewModel>();
            CreateMap<Pagamento, PagamentoViewModel>();
            CreateMap<Pagamento_Ficha, Pagamento_FichaViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Venda, VendaViewModel>();
            CreateMap<Venda_Produto, Venda_ProdutoViewModel>();
        }
    }
}
