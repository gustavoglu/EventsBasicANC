using System;
using System.Collections.Generic;

namespace EventsBasicANC.ViewModels
{
    public class PagamentoViewModel
    {
        public PagamentoViewModel()
        {
            Pagamento_Fichas = new List<Pagamento_FichaViewModel>();
        }

        public Guid Id { get; set; }

        public Guid Id_venda { get; set; }

        public double? Total { get; set; } = 0;

        public bool? Cancelado { get; set; } = false;

        public virtual ICollection<Pagamento_FichaViewModel> Pagamento_Fichas { get; set; }
    }
}
