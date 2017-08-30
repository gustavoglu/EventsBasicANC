using EventsBasicANC.Domain.Models.Enums;
using System;

namespace EventsBasicANC.ViewModels
{
    public class MovimentacaoViewModel
    {
        public MovimentacaoViewModel()
        {
            this.Data = DateTime.Now;
        }

        public Guid Id { get; set; }

        public Guid Id_ficha { get; set; } 

        public Guid? Id_Pagamento { get; set; }

        public MovimentacaoTipo MovimentacaoTipo { get; set; }

        public string Observacao { get; set; } = null;

        public double Valor { get; set; }

        public double SaldoAnterior{ get; set; }

        public DateTime? Data { get; set; }
    }
}
