using System;

namespace EventsBasicANC.ViewModels
{
    public class Venda_ProdutoViewModel
    {
        public Guid Id { get; set; }

        public Guid Id_venda { get; set; }

        public Guid Id_produto { get; set; }

        public int Quantidade { get; set; }

        public double ValorTotal { get; set; }
    }
}
