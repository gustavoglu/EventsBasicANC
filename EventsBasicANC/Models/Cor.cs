using System.Collections;
using System.Collections.Generic;

namespace EventsBasicANC.Models
{
    public class Cor : Entity
    {
        public string Descricao { get; set; } = null;

        public string CorFromHex { get; set; } = null;

        public ICollection<Produto> Produtos { get; set; }
    }
}
