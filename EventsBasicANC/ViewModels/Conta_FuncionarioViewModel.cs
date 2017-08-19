using System;

namespace EventsBasicANC.ViewModels
{
    public class Conta_FuncionarioViewModel
    {
        public Guid Id { get; set; }

        public Guid Id_funcionario { get; set; }

        public Guid Id_conta { get; set; }

        public DateTime Vencimento { get; set; }

        public bool Aprovador { get; set; }

        public bool Permanente { get; set; }

        public bool Ativo { get; set; }
    }
}
