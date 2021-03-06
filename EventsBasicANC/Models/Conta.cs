﻿using EventsBasicANC.Domain.Models.Enums;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Models
{
    public class Conta : Entity
    {
        public string Login { get; set; }

        public ContaTipo Tipo { get; set; }

        public string RazaoSocial { get; set; } = null;

        public string NomeFantasia { get; set; } = null;

        public Guid? Id_Conta_Principal { get; set; }

        public virtual Endereco Endereco { get; set; } = null;

        public virtual Contato Contato { get; set; } = null;

        public virtual ICollection<Venda> Vendas { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        public virtual ICollection<Contrato> Organizador_Contratos { get; set; }

        public virtual ICollection<Contrato> Loja_Contratos { get; set; }

        public virtual ICollection<Conta_Funcionario> Conta_Funcionarios { get; set; }

        public virtual ICollection<Conta_Funcionario> Funcionario_Contas { get; set; }

        public virtual Conta Conta_Principal { get; set; }
    }
}
