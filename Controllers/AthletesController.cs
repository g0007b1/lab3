using System;
using System.Collections.Generic;
using System.Linq;
using LW1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthletesController : ControllerBase
    {
        private static readonly IList<Athlete> MemCache = new List<Athlete>();

        // GET api/<AthletesController>
        [HttpGet]
        public ActionResult<IEnumerable<Athlete>> Get()
        {
            return MemCache.ToList();
        }

        // GET api/<AthletesController>/{id}
        [HttpGet("{id}")]
        public ActionResult<Athlete> Get(int id)
        {
            if (id < 0 || id >= MemCache.Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            return MemCache[id];
        }

        // POST api/<AthletesController>
        [HttpPost]
        public void Post([FromBody] Athlete value)
        {
            MemCache.Add(value);
        }

        // PUT api/<AthletesController>/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Athlete value)
        {
            if (id < 0 || id >= MemCache.Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            MemCache[id] = value;
        }

        // DELETE api/<AthletesController>/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id < 0 || id >= MemCache.Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            MemCache.RemoveAt(id);
        }
    }
}
