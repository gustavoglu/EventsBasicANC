using System;

namespace EventsBasicANC.ViewModels
{
    public class PagamentoViewModel
    {
        public Guid Id { get; set; }

        public Guid Id_venda { get; set; }

        public double Total { get; set; }

        public bool Cancelado { get; set; }
    }
}
