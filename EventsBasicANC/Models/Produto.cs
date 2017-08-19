using Events.Domain.Models.Enums;
using EventsBasicANC.Domain.Models.Enums;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Models
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }

        public double Preco { get; set; }

        public ProdutoTipo Tipo  { get; set; }

        public Guid Id_Cor { get; set; }

        public Guid  Id_loja { get; set; }


        public Cor Cor { get; set; }

        public virtual Conta Loja { get; set; }

        public virtual ICollection<Venda_Produto> Venda_Produtos { get; set; }
    }
}
