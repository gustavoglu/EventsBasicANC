using EventsBasicANC.Domain.Models.Enums;

namespace EventsBasicANC.ViewModels
{
    public class ProdutoContainerViewModel
    {
        public string Descricao { get; set; } = null;

        public double Valor { get; set; } = 0;

        public ProdutoTipo? Tipo  { get; set; }

    }
}
