using System.Collections.Generic;

namespace EventsBasicANC.Models
{
    public class Container
    {
        public Conta Organizador { get; set; }

        public ICollection<Conta> Organizador_Funcionarios { get; set; }

        public ICollection<Conta> Lojas { get; set; }
    }
}
