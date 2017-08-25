using System;

namespace EventsBasicANC.ViewModels
{
   public class Pagamento_FichaViewModel
    {
        public Guid Id { get; set; }

        public Guid Id_ficha { get; set; }

        public Guid Id_pagamento { get; set; }

        public double? Valor { get; set; } = 0;

        public virtual FichaViewModel Ficha { get; set; }
    }
}
