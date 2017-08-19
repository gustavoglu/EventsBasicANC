using System;

namespace EventsBasicANC.Models
{
    public class Contrato : Entity
    {
        public string Descricao { get; set; }

        public bool Aprovado { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataAprovacao { get; set; }

        public DateTime Vencimento { get; set; }

        public Guid Id_loja { get; set; }

        public Guid Id_organizador { get; set; }

        public Guid Id_evento { get; set; }

        public virtual Conta Loja { get; set; }

        public virtual Conta Organizador { get; set; }

        public virtual Evento Evento { get; set; }
    }
}
