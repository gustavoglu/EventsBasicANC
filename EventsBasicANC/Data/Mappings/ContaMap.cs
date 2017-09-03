using EventsBasicANC.Data.Extensions;
using EventsBasicANC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBasicANC.Data.Mappings
{
    public class ContaMap : EntityTypeConfiguration<Conta>
    {
        public override void Map(EntityTypeBuilder<Conta> conta)
        {
            conta.HasKey(c => c.Id);

            conta.HasOne(c => c.Conta_Principal)
                .WithOne()
                .HasForeignKey<Conta>(c => c.Id_Conta_Principal)
                .IsRequired(false)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            conta.HasOne(c => c.Endereco)
                .WithOne(e => e.Conta)
                .HasForeignKey<Endereco>(e => e.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            conta.HasOne(c => c.Contato)
                .WithOne(e => e.Conta)
                .HasForeignKey<Contato>(e => e.Id)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);


            //conta.HasOne(c => c.Conta_Principal)
            //    .WithOne(e => e.)
            //    .HasForeignKey<Conta>(e => e.Id)
            //    .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            conta.HasMany(c => c.Produtos)
                .WithOne(p => p.Loja)
                .HasForeignKey(p => p.Id_loja)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            conta.HasMany(c => c.Organizador_Contratos)
                .WithOne(p => p.Organizador)
                .HasForeignKey(p => p.Id_organizador)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            conta.HasMany(c => c.Loja_Contratos)
               .WithOne(p => p.Loja)
               .HasForeignKey(p => p.Id_loja)
               .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            //conta.HasMany(c => c.Conta_Funcionarios)
            //    .WithOne(p => p.Conta)
            //    .HasForeignKey(p => p.Id_funcionario)
            //    .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            //conta.HasMany(c => c.Conta_Funcionarios)
            //    .WithOne(p => p.Funcionario)
            //    .HasForeignKey(p => p.Id_conta)
            //    .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);


            conta.HasMany(c => c.Vendas)
                .WithOne(v => v.Conta)
                .HasForeignKey(v => v.Id_loja)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            conta.HasMany(c => c.Eventos)
                .WithOne(e => e.Organizador)
                .HasForeignKey(e => e.Id_organizador)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
