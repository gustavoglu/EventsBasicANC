using System;
using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventsBasicANC.Data.Repository
{
    public class ContratoRepository : Repository<Contrato>, IContratoRepository
    {
        public ContratoRepository(SQLSContext sqlsContext) : base(sqlsContext)
        {
            
        }
    }
}
