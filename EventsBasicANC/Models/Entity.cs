using System;

namespace EventsBasicANC.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; set; }

        public string CriadoPor { get; set; } = null;

        public string DeletadoPor { get; set; } = null;

        public string AtualizadoPor { get; set; } = null;

        public DateTime? CriadoEm { get; set; }

        public DateTime? DeletadoEm { get; set; }

        public DateTime? AtualizadoEm { get; set; }

        public bool Deletado { get; set; } = false;
    }
}
