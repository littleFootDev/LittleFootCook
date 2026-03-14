using System;
using System.Collections.Generic;
using System.Text;

namespace LittleFootCook.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public override bool Equals(object? obj)
        {

            if (obj is not Entity other) return false;

            return Id == other.Id;
        }
        public override int GetHashCode() => Id.GetHashCode();
    }
}
