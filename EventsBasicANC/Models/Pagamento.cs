using System;
using System.Collections.Generic;

namespace EventsBasicANC.Models
{
    public class Pagamento : Entity
    {
        public Guid Id_venda { get; set; }

        public double Total { get; set; }

        public bool Cancelado { get; set; }

        public virtual Venda Venda { get; set; }

        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }
    }
}
