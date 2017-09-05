using System;

namespace EventsBasicANC.Models
{
    public class Endereco : Entity
    {
        public string Rua { get; set; } = null;

        public string Bairro { get; set; } = null;

        public string Cidade { get; set; } = null;

        public string Estado { get; set; } = null;

        public string Numero { get; set; } = null;

        public string Complemento { get; set; } = null;

        public virtual Conta Conta { get; set; }
    }
}
