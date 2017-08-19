using System;

namespace EventsBasicANC.ViewModels
{
    public class ContratoViewModel
    {
        public string Descricao { get; set; }

        public bool Aprovado { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataAprovacao { get; set; }

        public DateTime Vencimento { get; set; }

        public Guid Id_loja { get; set; }

        public Guid Id_organizador { get; set; }

        public Guid Id_evento { get; set; }

    }
}
