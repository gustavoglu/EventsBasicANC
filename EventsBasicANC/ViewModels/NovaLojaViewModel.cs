using System;
namespace EventsBasicANC.ViewModels
{
    public class NovaLojaViewModel
    {
        public string Login { get; set; } = null;

        public string Senha { get; set; } = null;

        public string RazaoSocial { get; set; } = null;

        public string NomeFantasia { get; set; } = null;

        public Guid Id_conta_organizador { get; set; }

        public Guid Id_evento { get; set; }

        public EnderecoContainerViewModel Endereco { get; set; } = null;

        public ContatoContainerViewModel Contato { get; set; } = null;


    }
}
