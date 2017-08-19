﻿using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Services.Interfaces
{
    public interface IVendaAppService
    {
        VendaViewModel Criar(VendaViewModel entity);

        VendaViewModel Criar(ICollection<VendaViewModel> entitys);

        VendaViewModel Atualizar(VendaViewModel entity);

        VendaViewModel Deletar(Guid id);

        VendaViewModel TrazerPorId(Guid id);

        VendaViewModel TrazerAtivoPorId(Guid id);

        VendaViewModel TrazerDeletadoPorId(Guid id);

        IEnumerable<VendaViewModel> TrazerTodos();

        IEnumerable<VendaViewModel> TrazerTodosAtivos();

        IEnumerable<VendaViewModel> TrazerTodosDeletados();
    }
}