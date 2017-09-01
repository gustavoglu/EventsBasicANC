using System.Collections.Generic;

namespace EventsBasicANC.ViewModels
{
    public class ContainerViewModel
    {
        public EventoContainerViewModel Evento { get; set; }

        public OrganizadorContainerViewModel Organizador { get; set; }

        public ICollection<NovaLojaViewModel> Lojas { get; set; }
    }
}
