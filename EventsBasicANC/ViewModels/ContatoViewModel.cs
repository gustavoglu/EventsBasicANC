
using System;

namespace EventsBasicANC.ViewModels
{
    public class ContatoViewModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = null;

        public string EmailAdicional { get; set; } = null;

        public string Telefone { get; set; } = null;

        public string Telefone2 { get; set; } = null;

    }
}
