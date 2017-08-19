using EventsBasicANC.Domain.Models.Enums;
using System;

namespace EventsBasicANC.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public double Preco { get; set; }

        public ProdutoTipo Tipo  { get; set; }

        public Guid Id_Cor { get; set; }

        public Guid  Id_loja { get; set; }
    }
}
