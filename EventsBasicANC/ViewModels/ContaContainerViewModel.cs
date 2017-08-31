using EventsBasicANC.Domain.Models.Enums;
using System;

namespace EventsBasicANC.ViewModels
{
    public class ContaContainerViewModel
    {
        public string Login { get; set; }

        public string Senha { get; set; }

        public string RazaoSocial { get; set; } = null;

        public string NomeLoja { get; set; } = null;

        public EnderecoViewModel Endereco { get; set; } = null;

        public ContatoViewModel Contato { get; set; } = null;

    }
}
