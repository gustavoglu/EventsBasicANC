using System;

namespace EventsBasicANC.Models
{
   public class Pagamento_Ficha : Entity
    {
        public Guid Id_ficha { get; set; }

        public Guid Id_pagamento { get; set; }

        public double? Valor { get; set; } = 0;

        public Ficha Ficha { get; set; }

        public virtual Pagamento Pagamento { get; set; }
    }
}
