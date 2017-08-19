using EventsBasicANC.Domain.Models.Enums;
using System;

namespace EventsBasicANC.ViewModels
{
    public class ContaViewModel
    {
        public Guid Id { get; set; }

        public ContaTipo Tipo { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DocumentoTipo DocumentoTipo { get; set; }

        public string Documento { get; set; }

        public DateTime DataNascimento { get; set; }

        public string RazaoSocial { get; set; }

        public Guid Id_Conta_Principal { get; set; }
    }
}
