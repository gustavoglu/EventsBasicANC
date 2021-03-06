﻿using EventsBasicANC.Data.Extensions;
using EventsBasicANC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBasicANC.Data.Mappings
{
    public class Conta_FuncionarioMap : EntityTypeConfiguration<Conta_Funcionario>
    {
        public override void Map(EntityTypeBuilder<Conta_Funcionario> conta_funcionario)
        {
            conta_funcionario.HasKey(cf => cf.Id);

            conta_funcionario.HasOne(cf => cf.Funcionario)
                .WithMany(f => f.Conta_Funcionarios)
                .HasForeignKey(cf => cf.Id_funcionario)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            conta_funcionario.HasOne(cf => cf.Conta)
                .WithMany(f => f.Funcionario_Contas)
                .HasForeignKey(cf => cf.Id_conta)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
