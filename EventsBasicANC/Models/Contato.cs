

namespace EventsBasicANC.Models
{
    public class Contato : Entity
    {
        public string Email { get; set; }

        public string EmailAdicional { get; set; }

        public string Telefone { get; set; }

        public string Telefone2 { get; set; }

        public virtual Conta Conta  { get; set; }
    }
}
