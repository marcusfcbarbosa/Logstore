using System;
using FluentValidator;
using Logstore.Shared.Interfaces;

namespace Logstore.Shared.Entities
{
    public abstract class Entity : Notifiable, IEntity
    {
        public Entity()
        {
            this.CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        public string identifyer { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}