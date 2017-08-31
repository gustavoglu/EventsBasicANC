using System.Collections.Generic;

namespace EventsBasicANC.ViewModels
{
    public class OrganizadorContainerViewModel : ContaBasicaContainerViewModel
    {
        public ICollection<ContaBasicaContainerViewModel> Funcionarios { get; set; }
    }
}
