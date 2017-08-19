﻿using EventsBasicANC.Models;
using System;

namespace EventsBasicANC.Models
{
    public class Conta_Funcionario : Entity
    {
        public Guid Id_funcionario { get; set; }

        public Guid Id_conta { get; set; }

        public DateTime Vencimento { get; set; }

        public bool Aprovador { get; set; }

        public bool Permanente { get; set; }

        public bool Ativo { get; set; }


        public virtual Conta Funcionario  { get; set; }

        public virtual Conta Conta  { get; set; }
    }
}
