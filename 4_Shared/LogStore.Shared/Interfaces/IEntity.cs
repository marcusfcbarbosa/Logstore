using System;

namespace Logstore.Shared.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        string identifyer { get; set; }
        DateTime CreatedAt { get; set; }
    }
}