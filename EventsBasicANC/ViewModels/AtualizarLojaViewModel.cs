using System;

namespace EventsBasicANC.ViewModels
{
    public class AtualizarLojaViewModel
    {
        public Guid Id { get; set; }

        public string Login { get; set; } = null;

        public string RazaoSocial { get; set; } = null;

        public string NomeFantasia { get; set; } = null;

        public EnderecoContainerViewModel Endereco { get; set; } = null;

        public ContatoContainerViewModel Contato { get; set; } = null;
    }
}
