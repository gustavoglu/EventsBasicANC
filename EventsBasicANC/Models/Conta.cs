using EventsBasicANC.Domain.Models.Enums;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Models
{
    public class Conta : Entity
    {
        public ContaTipo Tipo { get; set; }

        public string Nome { get; set; } = null;

        public string Sobrenome { get; set; } = null;

        public DocumentoTipo DocumentoTipo { get; set; }

        public string Documento { get; set; } = null;

        public DateTime? DataNascimento { get; set; } = null;

        public string RazaoSocial { get; set; } = null;

        public Guid? Id_Conta_Principal { get; set; }

        public virtual Endereco Endereco { get; set; } = null;

        public virtual Contato Contato { get; set; } = null;

        public virtual ICollection<Venda> Vendas { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        public virtual ICollection<Contrato> Organizador_Contratos { get; set; }

        public virtual ICollection<Contrato> Loja_Contratos { get; set; }

        public virtual ICollection<Conta_Funcionario> Conta_Funcionarios { get; set; }

        public virtual Conta_Funcionario Conta_Principal { get; set; } 
    }
}
