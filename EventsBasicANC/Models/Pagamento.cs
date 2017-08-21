using System;
using System.Collections.Generic;

namespace EventsBasicANC.Models
{
    public class Pagamento : Entity
    {
        public Guid Id_venda { get; set; }

        public double? Total { get; set; } = 0;

        public bool? Cancelado { get; set; } = false;

        public virtual Venda Venda { get; set; }

        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }

        public virtual ICollection<Pagamento_Ficha> Pagamento_Fichas { get; set; }
    }
}
