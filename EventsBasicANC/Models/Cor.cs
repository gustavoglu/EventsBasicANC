using System.Collections;
using System.Collections.Generic;

namespace EventsBasicANC.Models
{
    public class Cor : Entity
    {
        public string Descricao { get; set; }

        public string CorFromHex { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
