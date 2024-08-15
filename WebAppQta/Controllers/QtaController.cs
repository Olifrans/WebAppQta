using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppQta;
using WebAppQta.Models;

namespace WebAppQta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QtaController : ControllerBase
    {
        private readonly WebAppQtaContext _context;

        public QtaController(WebAppQtaContext context)
        {
            _context = context;
        }

        // GET: api/Qta
        [HttpGet]
        public IEnumerable<Qta> GetQta()
        {
            return _context.Qta;
        }

        // GET: api/Qta/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQta([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var qta = await _context.Qta.FindAsync(id);

            if (qta == null)
            {
                return NotFound();
            }

            return Ok(qta);
        }

        // PUT: api/Qta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQta([FromRoute] Guid id, [FromBody] Qta qta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != qta.Id)
            {
                return BadRequest();
            }

            _context.Entry(qta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QtaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Qta
        [HttpPost]
        public async Task<IActionResult> PostQta([FromBody] Qta qta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Qta.Add(qta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQta", new { id = qta.Id }, qta);
        }

        // DELETE: api/Qta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQta([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var qta = await _context.Qta.FindAsync(id);
            if (qta == null)
            {
                return NotFound();
            }

            _context.Qta.Remove(qta);
            await _context.SaveChangesAsync();

            return Ok(qta);
        }

        private bool QtaExists(Guid id)
        {
            return _context.Qta.Any(e => e.Id == id);
        }
    }
}