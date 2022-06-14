using System;

namespace Sale.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime CreateAt { get; private set; }
        public Entity()
        {
            CreateAt = DateTime.Now;
        }
    }
}