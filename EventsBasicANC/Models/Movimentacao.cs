using EventsBasicANC.Domain.Models.Enums;
using System;

namespace EventsBasicANC.Models
{
    public class Movimentacao : Entity
    {
        public Guid Id_ficha { get; set; } 

        public Guid? Id_Pagamento { get; set; }

        public MovimentacaoTipo MovimentacaoTipo { get; set; }

        public string Observacao { get; set; } = null;

        public double? Valor { get; set; } = 0;

        public double? SaldoAnterior { get; set; } = 0;

        public virtual Ficha Ficha { get; set; }

        public virtual Pagamento Pagamento { get; set; }
    }
}
