using System;
using System.Collections.Generic;

namespace EventsBasicANC.ViewModels
{
    public class VendaViewModel
    {
        public VendaViewModel()
        {
            this.Id = Guid.NewGuid();
            Venda_Produtos = new List<Venda_ProdutoViewModel>();
            Pagamentos = new List<PagamentoViewModel>();
        }

        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public bool Cancelada { get; set; } = false;

        public double? Total { get; set; } = 0;

        public Guid Id_loja { get; set; }

        public Guid Id_Evento { get; set; }

        public virtual PagamentoViewModel Pagamento { get; set; }

        public virtual ICollection<Venda_ProdutoViewModel> Venda_Produtos { get; set; }

        public virtual ICollection<PagamentoViewModel> Pagamentos { get; set; }
    }
}
