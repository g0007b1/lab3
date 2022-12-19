using LW1.Controllers.Memory.Interfaces;
using LW1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LW1.Controllers.Memory
{
    public class MemCache : IStorage<Athlete>
    {
        private readonly object _sync = new object();
        private readonly List<Athlete> _memCache = new List<Athlete>();
        public List<Athlete> All => _memCache.ToList();

        public Athlete this[Guid id]
        {
            get
            {
                lock (_sync)
                {
                    if (!Has(id))
                    {
                        throw new IncorrectAthleteException($"No Athlete with id {id}");
                    }

                    return _memCache.Single(x => x.Id == id);
                }
            }
            set
            {
                if (id == Guid.Empty)
                {
                    throw new IncorrectAthleteException("Cannot request Athlete with an empty id");
                }

                lock (_sync)
                {
                    if (Has(id))
                    {
                        RemoveAt(id);
                    }

                    value.Id = id;
                    _memCache.Add(value);
                }
            }
        }

        public void Add(Athlete value)
        {
            if (value.Id != Guid.Empty)
            {
                throw new IncorrectAthleteException($"Cannot add value with predefined id {value.Id}");
            }

            value.Id = Guid.NewGuid();
            this[value.Id] = value;
        }

        public void RemoveAt(Guid id)
        {
            lock (_sync)
            {
                _memCache.RemoveAll(x => x.Id == id);
            }
        }

        public bool Has(Guid id)
        {
            return _memCache.Any(x => x.Id == id);
        }
    }
}
