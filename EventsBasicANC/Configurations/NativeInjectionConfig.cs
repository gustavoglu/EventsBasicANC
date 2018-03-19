using EventsBasicANC.Data;
using EventsBasicANC.Data.Repository;
using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Interfaces;
using EventsBasicANC.Services;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.Users;
using EventsBasicANC.Util;
using Microsoft.Extensions.DependencyInjection;

namespace EventsBasicANC.Configurations
{
    public class NativeInjectionConfig
    {
        public static void Configure(IServiceCollection services)
        {
            //Injeção de Dependencia
            services.AddScoped<SQLSContext>();

            //Repository
            services.AddScoped<IConta_FuncionarioRepository, Conta_FuncionarioRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IContratoRepository, ContratoRepository>();
            services.AddScoped<ICorRepository, CorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IFichaRepository, FichaRepository>();
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
            services.AddScoped<IPagamento_FichaRepository, Pagamento_FichaRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IVenda_ProdutoRepository, Venda_ProdutoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();

            //AppService
            services.AddScoped<IConta_FuncionarioAppService, Conta_FuncionarioAppService>();
            services.AddScoped<IContaAppService, ContaAppService>();
            services.AddScoped<IContatoAppService, ContatoAppService>();
            services.AddScoped<IContratoAppService, ContratoAppService>();
            services.AddScoped<ICorAppService, CorAppService>();
            services.AddScoped<IEnderecoAppService, EnderecoAppService>();
            services.AddScoped<IEventoAppService, EventoAppService>();
            services.AddScoped<IFichaAppService, FichaAppService>();
            services.AddScoped<IMovimentacaoAppService, MovimentacaoAppService>();
            services.AddScoped<IPagamento_FichaAppService, Pagamento_FichaAppService>();
            services.AddScoped<IPagamentoAppService, PagamentoAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IVenda_ProdutoAppService, Venda_ProdutoAppService>();
            services.AddScoped<IVendaAppService, VendaAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<UsuarioAppService>();

            //Users
            services.AddScoped<IUser, AspNetUser>();

            //Util
            services.AddScoped<EasyClaims>();
        }
    }
}
