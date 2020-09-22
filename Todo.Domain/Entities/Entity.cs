using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity> //Permite executar comparações
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}
