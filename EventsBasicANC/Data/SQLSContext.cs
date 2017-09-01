using EventsBasicANC.Data.Extensions;
using EventsBasicANC.Data.Mappings;
using EventsBasicANC.Interfaces;
using EventsBasicANC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EventsBasicANC.Data
{
    public class SQLSContext : IdentityDbContext<Usuario>
    {
        private readonly IUser _user;

        public SQLSContext(IUser user)
        {
            _user = user;
        }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Conta_Funcionario> Conta_Funcionarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Pagamento_Ficha> Pagamento_Fichas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Venda_Produto> Venda_Produtos { get; set; }
        public DbSet<Cor> Cores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
     
            base.OnModelCreating(modelBuilder);

            

            // Altera nome de tabelas do Entity
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("Usuario_Regra");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("Login");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("Claim");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("Token");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("Regra_Claim");
            modelBuilder.Entity<IdentityRole>().ToTable("Regra");

            //Configura Entitys
            modelBuilder.AddConfiguration(new ContaMap());
            modelBuilder.AddConfiguration(new Conta_FuncionarioMap());
            modelBuilder.AddConfiguration(new ContatoMap());
            modelBuilder.AddConfiguration(new ContratoMap());
            modelBuilder.AddConfiguration(new EnderecoMap());
            modelBuilder.AddConfiguration(new EventoMap());
            modelBuilder.AddConfiguration(new FichaMap());
            modelBuilder.AddConfiguration(new MovimentacaoMap());
            modelBuilder.AddConfiguration(new PagamentoMap());
            modelBuilder.AddConfiguration(new Pagamento_FichaMap());
            modelBuilder.AddConfiguration(new ProdutoMap());
            modelBuilder.AddConfiguration(new VendaMap());
            modelBuilder.AddConfiguration(new Venda_ProdutoMap());
            modelBuilder.AddConfiguration(new CorMap());

        }

        public override int SaveChanges()
        {
            var criados = ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Added);
            var atualizados = ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Modified);
            var deletados = ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Deleted);

            if (criados.Any()) CriaEntidades(criados);
            if (atualizados.Any()) AtualizaEntidades(atualizados);
            if (deletados.Any()) DeletaEntidades(deletados);

            return base.SaveChanges();
        }

        private void AtualizaEntidades(IEnumerable<EntityEntry> atualizados)
        {
            foreach (var entity in atualizados)
            {
                var entityAtualizada = (Entity)entity.Entity;
                entityAtualizada.AtualizadoEm = DateTime.Now;

                if (_user.IsAuthenticated())
                    entityAtualizada.AtualizadoPor = _user.Name;
                
            }
        }

        private void CriaEntidades(IEnumerable<EntityEntry> criados)
        {
            foreach (var entity in criados)
            {
                var entityCriada = (Entity)entity.Entity;
                entityCriada.CriadoEm = DateTime.Now;
                if (_user.IsAuthenticated())
                    entityCriada.CriadoPor = _user.Name;
            }
        }

        private void DeletaEntidades(IEnumerable<EntityEntry> deletados)
        {
            foreach (var entity in deletados)
            {
                entity.State = EntityState.Modified;
                var entityCriada = (Entity)entity.Entity;
                entityCriada.DeletadoEm = DateTime.Now;
                entityCriada.Deletado = true;

                if (_user.IsAuthenticated())
                    entityCriada.DeletadoPor = _user.Name;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

    }
}
