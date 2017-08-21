

namespace EventsBasicANC.Models
{
    public class Contato : Entity
    {
        public string Email { get; set; } = null;

        public string EmailAdicional { get; set; } = null;

        public string Telefone { get; set; } = null;

        public string Telefone2 { get; set; } = null;

        public virtual Conta Conta  { get; set; }
    }
}
