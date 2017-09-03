using EventsBasicANC.Domain.Models.Enums;
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

        public string Rua { get; set; } = null;

        public string Bairro { get; set; } = null;

        public string Cidade { get; set; } = null;

        public string Estado { get; set; } = null;

        public string NomeCompleto { get; set; } = null;

        public DocumentoTipo? DocumentoTipo { get; set; }

        public string Documento { get; set; } = null;

        public string Email { get; set; } = null;

        public string EmailAdicional { get; set; } = null;

        public string Telefone { get; set; } = null;

        public string Telefone2 { get; set; } = null;



    }
}
