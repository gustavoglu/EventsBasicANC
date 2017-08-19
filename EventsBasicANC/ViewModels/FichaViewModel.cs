using System;

namespace EventsBasicANC.ViewModels
{
    public class FichaViewModel
    {
        public Guid Id { get; set; }

        public double Saldo { get; set; } = 0;

        public string NomeCliente { get; set; }
    }
}