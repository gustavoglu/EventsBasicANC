using System;

namespace EventsBasicANC.ViewModels
{
    public class EnderecoViewModel
    {
        public string Rua { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Pais { get; set; }

        public virtual ContaViewModel Conta { get; set; }
    }
}
