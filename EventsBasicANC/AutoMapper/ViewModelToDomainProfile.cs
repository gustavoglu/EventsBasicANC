using AutoMapper;
using EventsBasicANC.Models;
using EventsBasicANC.ViewModels;

namespace EventsBasicANC.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<Conta, ContaViewModel>()
                .ReverseMap()
                //.ForMember(c => c.Endereco, cfg => cfg.Ignore())
                //.ForMember(c => c.Contato, cfg => cfg.Ignore())
                .ForMember(c => c.Vendas, cfg => cfg.Ignore())
                .ForMember(c => c.Eventos, cfg => cfg.Ignore())
                .ForMember(c => c.Produtos, cfg => cfg.Ignore())
                .ForMember(c => c.Organizador_Contratos, cfg => cfg.Ignore())
                .ForMember(c => c.Loja_Contratos, cfg => cfg.Ignore())
                .ForMember(c => c.Conta_Funcionarios, cfg => cfg.Ignore())
                .ForMember(c => c.Funcionario_Contas, cfg => cfg.Ignore())
                .ForMember(c => c.Conta_Principal, cfg => cfg.Ignore())
                ;
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
            CreateMap<Conta_Funcionario, Conta_FuncionarioViewModel>().ReverseMap();
            CreateMap<Contrato, ContratoViewModel>().ReverseMap();
            CreateMap<Cor, CorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Evento, EventoViewModel>().ReverseMap();
            CreateMap<Ficha, FichaViewModel>().ReverseMap();
            CreateMap<Movimentacao, MovimentacaoViewModel>().ReverseMap();
            CreateMap<Pagamento, PagamentoViewModel>().ReverseMap();
            CreateMap<Pagamento_Ficha, Pagamento_FichaViewModel>().ReverseMap()
                .ForMember(vm => vm.Ficha, cfg => cfg.Ignore());
               
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Venda, VendaViewModel>().ReverseMap();
            CreateMap<Venda_Produto, Venda_ProdutoViewModel>().ReverseMap();
        }
    }
}
