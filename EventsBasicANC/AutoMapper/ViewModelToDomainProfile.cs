using AutoMapper;
using EventsBasicANC.Models;
using EventsBasicANC.ViewModels;

namespace EventsBasicANC.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<Conta, ContaViewModel>().ReverseMap();
            CreateMap<Conta_Funcionario, Conta_FuncionarioViewModel>().ReverseMap();
            CreateMap<Contrato, ContratoViewModel>().ReverseMap();
            CreateMap<Cor, CorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Evento, EventoViewModel>().ReverseMap();
            CreateMap<Ficha, FichaViewModel>().ReverseMap();
            CreateMap<Movimentacao, MovimentacaoViewModel>().ReverseMap();
            CreateMap<Pagamento, PagamentoViewModel>().ReverseMap();
            CreateMap<Pagamento_Ficha, Pagamento_FichaViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Venda, VendaViewModel>().ReverseMap();
            CreateMap<Venda_Produto, Venda_ProdutoViewModel>().ReverseMap();
        }
    }
}
