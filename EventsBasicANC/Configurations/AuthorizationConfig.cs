using Microsoft.Extensions.DependencyInjection;

namespace EventsBasicANC.Configurations
{
    public class AuthorizationConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));

                opt.AddPolicy("EventosAdicionar", policy => policy.RequireClaim("Eventos", "Ad"));
                opt.AddPolicy("EventosEditar", policy => policy.RequireClaim("Eventos", "Ed"));
                opt.AddPolicy("EventosVisualizar", policy => policy.RequireClaim("Eventos", "Vi"));
                opt.AddPolicy("EventosDeletar", policy => policy.RequireClaim("Eventos", "Ex"));

                opt.AddPolicy("VendasCancelar", policy => policy.RequireClaim("Vendas", "Ca"));
                opt.AddPolicy("VendasAdicionar", policy => policy.RequireClaim("Vendas", "Ad"));
                opt.AddPolicy("VendasEditar", policy => policy.RequireClaim("Vendas", "Ed"));
                opt.AddPolicy("VendasVisualizar", policy => policy.RequireClaim("Vendas", "Vi"));
                opt.AddPolicy("VendasDeletar", policy => policy.RequireClaim("Vendas", "Ex"));

                opt.AddPolicy("ProdutosAdicionar", policy => policy.RequireClaim("Produtos", "Ad"));
                opt.AddPolicy("ProdutosEditar", policy => policy.RequireClaim("Produtos", "Ed"));
                opt.AddPolicy("ProdutosVisualizar", policy => policy.RequireClaim("Produtos", "Vi"));
                opt.AddPolicy("ProdutosDeletar", policy => policy.RequireClaim("Produtos", "Ex"));

                opt.AddPolicy("LojasAdicionar", policy => policy.RequireClaim("Lojas", "Ad"));
                opt.AddPolicy("LojasEditar", policy => policy.RequireClaim("Lojas", "Ed"));
                opt.AddPolicy("LojasVisualizar", policy => policy.RequireClaim("Lojas", "Vi"));
                opt.AddPolicy("LojasDeletar", policy => policy.RequireClaim("Lojas", "Ex"));

                opt.AddPolicy("FuncionariosAdicionar", policy => policy.RequireClaim("Funcionarios", "Ad"));
                opt.AddPolicy("FuncionariosEditar", policy => policy.RequireClaim("Funcionarios", "Ed"));
                opt.AddPolicy("FuncionariosVisualizar", policy => policy.RequireClaim("Funcionarios", "Vi"));
                opt.AddPolicy("FuncionariosDeletar", policy => policy.RequireClaim("Funcionarios", "Ex"));

                opt.AddPolicy("FichasAdicionar", policy => policy.RequireClaim("Fichass", "Ad"));
                opt.AddPolicy("FichasEditar", policy => policy.RequireClaim("Fichas", "Ed"));
                opt.AddPolicy("FichasVisualizar", policy => policy.RequireClaim("Fichas", "Vi"));
                opt.AddPolicy("FichasDeletar", policy => policy.RequireClaim("Fichas", "Ex"));

            });
        }
    }
}
