using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventsBasicANC.Models;
using Microsoft.AspNetCore.Identity;
using EventsBasicANC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using EventsBasicANC.Authorization;
using System.Text;
using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Data.Repository;

namespace EventsBasicANC
{
    public class Startup
    {

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }


        private const string SecretKey = "BaseProjectAspNetCoreSercretKey";
        private readonly SymmetricSecurityKey _signKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SQLSContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectoin")));

            services.AddIdentity<Usuario, IdentityRole>()
                .AddEntityFrameworkStores<SQLSContext>()
                .AddDefaultTokenProviders();

            ConfigureJwtAuthService(services);

            services.AddOptions();
            services.AddMvc(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                //  options.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"));
                var policy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            });

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

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(c => { c.AllowAnyHeader(); c.AllowAnyMethod(); c.AllowAnyOrigin(); });
            app.UseAuthentication();
            app.UseMvc();
        }

        public void ConfigureJwtAuthService(IServiceCollection services)
        {
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtTokenOptions));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtTokenOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtTokenOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services.Configure<JwtTokenOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtTokenOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtTokenOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signKey, SecurityAlgorithms.HmacSha256);
            });

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o => { o.TokenValidationParameters = tokenValidationParameters; });
        }
    }
}
