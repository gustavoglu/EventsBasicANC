using System;

namespace EventsBasicANC.ViewModels
{
    public class EventoViewModel
    {
        public Guid? Id { get; set; }

        public string Descricao { get; set; } = null;

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public Guid Id_organizador { get; set; }

        public bool? Cancelado { get; set; } = false;

    }
}