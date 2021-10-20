using System;

namespace CityWeb.Domain.Entities
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
