﻿using EventsBasicANC.Domain.Models.Enums;
using System;

namespace EventsBasicANC.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }

        public string Descricao { get; set; } = null;

        public double? Preco { get; set; } = 0;

        public ProdutoTipo Tipo { get; set; }

        public Guid? Id_Cor { get; set; }

        public Guid Id_loja { get; set; }
    }
}
