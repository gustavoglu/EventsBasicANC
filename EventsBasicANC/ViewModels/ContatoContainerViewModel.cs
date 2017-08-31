using EventsBasicANC.Domain.Models.Enums;

namespace EventsBasicANC.ViewModels
{
    public class ContatoContainerViewModel
    {
        public string NomeCompleto { get; set; } = null;

        public DocumentoTipo DocumentoTipo { get; set; }

        public string Documento { get; set; } = null;

        public string Email { get; set; } = null;

        public string EmailAdicional { get; set; } = null;

        public string Telefone { get; set; } = null;

        public string Telefone2 { get; set; } = null;
    }
}
