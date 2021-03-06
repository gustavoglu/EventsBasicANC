﻿using System;

namespace EventsBasicANC.ViewModels
{
    public class FichaViewModel
    {
        public FichaViewModel()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public Guid Id_evento { get; set; }

        public string Codigo { get; set; } = null;

        public double Saldo { get; set; } = 0;

        public string NomeCliente { get; set; } = null;

    }
}