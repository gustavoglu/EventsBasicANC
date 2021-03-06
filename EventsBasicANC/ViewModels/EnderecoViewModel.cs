﻿using System;

namespace EventsBasicANC.ViewModels
{
    public class EnderecoViewModel
    {
        public Guid Id { get; set; }

        public string Rua { get; set; } = null;

        public string Bairro { get; set; } = null;

        public string Cidade { get; set; } = null;

        public string Estado { get; set; } = null;

        public string Numero { get; set; } = null;

        public string Complemento { get; set; } = null;

    }
}
