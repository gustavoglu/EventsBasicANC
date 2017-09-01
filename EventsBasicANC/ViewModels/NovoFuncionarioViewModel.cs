using System;

namespace EventsBasicANC.ViewModels
{
    public class NovoFuncionarioViewModel
    {
        public string NomeCompleto { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public Guid Id_conta { get; set; }
    }
}
