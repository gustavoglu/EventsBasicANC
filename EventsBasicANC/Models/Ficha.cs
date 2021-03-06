﻿using System;
using System.Collections.Generic;

namespace EventsBasicANC.Models
{
    public class Ficha : Entity
    {
        public string Codigo { get; set; } = null;

        public double Saldo { get; set; } = 0;

        public string NomeCliente { get; set; } = null;

        public Guid Id_evento { get; set; }

        public ICollection<Pagamento_Ficha> Pagamento_Fichas { get; set; }

        public ICollection<Movimentacao> Movimentacoes { get; set; }

        public virtual Evento Evento  { get; set; }

    }
}