using EventsBasicANC.Domain.Models.Enums;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Models
{
    public class Conta : Entity
    {
        public ContaTipo Tipo { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DocumentoTipo DocumentoTipo { get; set; }

        public string Documento { get; set; }

        public DateTime DataNascimento { get; set; }

        public string RazaoSocial { get; set; }

        public Guid Id_Conta_Principal { get; set; }

        public virtual Endereco Endereco { get; set; }

        public virtual Contato Contato { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        public virtual ICollection<Contrato> Organizador_Contratos { get; set; }

        public virtual ICollection<Contrato> Loja_Contratos { get; set; }

        public virtual ICollection<Conta_Funcionario> Conta_Funcionarios { get; set; }

        public virtual Conta_Funcionario Conta_Principal { get; set; }
    }
}
