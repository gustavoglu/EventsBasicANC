using System;

namespace EventsBasicANC.ViewModels
{
    public class VendaViewModel
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public bool Cancelada { get; set; } = false;

        public double Total { get; set; }

        public Guid Id_loja { get; set; }

        public Guid Id_Evento { get; set; }

    }
}
