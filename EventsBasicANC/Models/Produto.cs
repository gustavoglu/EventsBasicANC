using EventsBasicANC.Domain.Models.Enums;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Models
{
    public class Produto : Entity
    {
        public string Descricao { get; set; } = null;

        public double? Preco { get; set; } = 0;

        public ProdutoTipo Tipo  { get; set; }

        public Guid? Id_Cor { get; set; } 

        public Guid  Id_loja { get; set; }

        public Cor Cor { get; set; }

        public virtual Conta Loja { get; set; }

        public virtual ICollection<Venda_Produto> Venda_Produtos { get; set; }
    }
}
