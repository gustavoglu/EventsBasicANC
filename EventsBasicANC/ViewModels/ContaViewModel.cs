using EventsBasicANC.Domain.Models.Enums;
using System;

namespace EventsBasicANC.ViewModels
{
    public class ContaViewModel
    {
        public Guid Id { get; set; }

        public ContaTipo Tipo { get; set; }

        public DocumentoTipo DocumentoTipo { get; set; }

        public string Documento { get; set; } = null;

        public DateTime? DataNascimento { get; set; } = null;

        public string RazaoSocial { get; set; } = null;

        public string NomeFantasia { get; set; } = null;

        public Guid? Id_Conta_Principal { get; set; }

        public virtual EnderecoViewModel Endereco { get; set; } = null;

        public virtual ContatoViewModel Contato { get; set; } = null;
    }
}
