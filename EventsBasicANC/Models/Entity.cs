using System;

namespace EventsBasicANC.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string CriadoPor { get; set; }

        public string DeletadoPor { get; set; }

        public string AtualizadoPor { get; set; }

        public DateTime CriadoEm { get; set; }

        public DateTime DeletadoEm { get; set; }

        public DateTime AtualizadoEm { get; set; }

        public bool Deletado { get; set; }
    }
}
