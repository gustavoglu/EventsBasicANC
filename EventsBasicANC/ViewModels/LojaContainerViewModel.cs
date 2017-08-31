using System.Collections.Generic;

namespace EventsBasicANC.ViewModels
{
    public class LojaContainerViewModel : ContaContainerViewModel
    {
        public ICollection<ProdutoViewModel> Produtos { get; set; }

        public ICollection<ContaContainerViewModel> Funcionarios { get; set; }
    }
}
