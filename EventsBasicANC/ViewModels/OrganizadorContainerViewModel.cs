using System.Collections.Generic;

namespace EventsBasicANC.ViewModels
{
    public class OrganizadorContainerViewModel : NovoFuncionarioViewModel
    {
        public ICollection<NovoFuncionarioViewModel> Funcionarios { get; set; }
    }
}
