using EventsBasicANC.Domain.Models.Enums;
using System;

namespace EventsBasicANC.ViewModels
{
    public class ContaContainerViewModel
    {
        public string Login { get; set; }

        public string Senha { get; set; }

        public string ConfirmacaoSenha { get; set; }

        public string Nome { get; set; } = null;

        public string Sobrenome { get; set; } = null;

        public DocumentoTipo DocumentoTipo { get; set; }

        public string Documento { get; set; } = null;

        public DateTime? DataNascimento { get; set; } = null;

        public string RazaoSocial { get; set; } = null;

        public EnderecoViewModel Endereco { get; set; } = null;

        public ContatoViewModel Contato { get; set; } = null;

    }
}
