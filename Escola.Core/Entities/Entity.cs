using System;
using System.ComponentModel.DataAnnotations;

namespace Escola.Core.Entity
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public abstract void Validar();
    }
}