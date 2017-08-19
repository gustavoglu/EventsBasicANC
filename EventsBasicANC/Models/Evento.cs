using System;
using System.Collections.Generic;

namespace EventsBasicANC.Models
{
    public class Evento : Entity
    {
        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public Guid Id_organizador { get; set; }

        public bool Cancelado { get; set; } = false;

        public virtual Conta Organizador { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }

        public virtual ICollection<Contrato> Contratos  { get; set; }

    }
}