namespace EventsBasicANC.Models
{
    public class Endereco : Entity
    {
        public string Rua { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Pais { get; set; }

        public virtual Conta Conta { get; set; }
    }
}
