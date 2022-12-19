using System;
using System.Collections.Generic;

namespace LW1.Controllers.Memory.Interfaces
{
    public interface IStorage<T> where T : class
    {
        List<T> All { get; }
        T this[Guid id] { get; set; }
        void Add(T value);
        void RemoveAt(Guid id);
        bool Has(Guid id);
    }
}
