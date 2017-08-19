
namespace EventsBasicANC.ViewModels
{
    public class ContatoViewModel
    {
        public string Email { get; set; }

        public string EmailAdicional { get; set; }

        public string Telefone { get; set; }

        public string Telefone2 { get; set; }

        public virtual ContaViewModel Conta  { get; set; }
    }
}
