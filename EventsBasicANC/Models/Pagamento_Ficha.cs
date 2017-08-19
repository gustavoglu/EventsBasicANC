using System;


namespace EventsBasicANC.Models
{
   public class Pagamento_Ficha : Entity
    {
        public Guid Id_ficha { get; set; }

        public double Valor { get; set; }

        public Ficha Ficha { get; set; }
    }
}
