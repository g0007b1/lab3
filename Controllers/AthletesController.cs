using System;
using System.Collections.Generic;
using LW1.Controllers.Memory;
using LW1.Controllers.Memory.Interfaces;
using LW1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthletesController : ControllerBase
    {
        private readonly IStorage<Athlete> _memCache;

        public AthletesController(IStorage<Athlete> memCache)
        {
            _memCache = memCache;
        }

        // GET api/<AthletesController>
        [HttpGet]
        public ActionResult<IEnumerable<Athlete>> Get()
        {
            return Ok(_memCache.All);
        }

        // GET api/<AthletesController>/{id}
        [HttpGet("{id}")]
        public ActionResult<Athlete> Get(Guid id)
        {
            if (!_memCache.Has(id)) return NotFound("No such");

            return Ok(_memCache[id]);
        }

        // POST api/<AthletesController>
        [HttpPost]
        public IActionResult Post([FromBody] Athlete value)
        {
            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            _memCache.Add(value);

            return Ok($"{value} has been added");
        }

        // PUT api/<AthletesController>/{id}
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Athlete value)
        {
            if (!_memCache.Has(id)) return NotFound("No such");

            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var previousValue = _memCache[id];
            _memCache[id] = value;

            return Ok($"{previousValue} has been updated to {value}");
        }

        // DELETE api/<AthletesController>/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_memCache.Has(id)) return NotFound("No such");

            var valueToRemove = _memCache[id];
            _memCache.RemoveAt(id);

            return Ok($"{valueToRemove} has been removed");
        }
    }
}