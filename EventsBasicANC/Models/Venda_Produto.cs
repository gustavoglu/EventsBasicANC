using System;

namespace EventsBasicANC.Models
{
    public class Venda_Produto : Entity
    {
        public Guid Id_venda { get; set; }

        public Guid Id_produto { get; set; }

        public int Quantidade { get; set; }

        public double ValorTotal { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual Venda Venda { get; set; }
    }
}
