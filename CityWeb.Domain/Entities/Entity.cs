using System;

namespace CityWeb.Domain.Entities
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
