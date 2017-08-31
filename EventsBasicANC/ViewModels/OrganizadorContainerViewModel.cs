using System.Collections.Generic;

namespace EventsBasicANC.ViewModels
{
    public class OrganizadorContainerViewModel : ContaContainerViewModel
    {
        public ICollection<ContaContainerViewModel> Funcionarios { get; set; }
    }
}
