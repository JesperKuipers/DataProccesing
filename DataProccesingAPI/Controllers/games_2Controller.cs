using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataProccesingAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace DataProccesingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class games_2Controller : ControllerBase
    {
        private readonly API_DB_context _context;

        public games_2Controller(API_DB_context context)
        {
            _context = context;
        }

        // GET: api/games_2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<games_2>>> Getgames_2([Required] int page, [Required] int size, string tableName, string tableContent)
        {
            return await _context.games_2.Skip(page * size).Take(size).ToListAsync();
        }

        // PUT: api/games_2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgames_2(long id, games_2 games_2)
        {
            if (id != games_2.steamid)
            {
                return BadRequest("Id doesn't match id in body!");
            }

            _context.Entry(games_2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!games_2Exists(id))
                {
                    return NotFound("The record doesn't exist *sad raccoon noises*");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/games_2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<games_2>> Postgames_2(games_2 games_2)
        {
            _context.games_2.Add(games_2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgames_2", new { id = games_2.steamid }, games_2);
        }

        // DELETE: api/games_2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletegames_2(long id)
        {
            var games_2 = await _context.games_2.FindAsync(id);
            if (games_2 == null)
            {
                return NotFound();
            }

            _context.games_2.Remove(games_2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool games_2Exists(long id)
        {
            return _context.games_2.Any(e => e.steamid == id);
        }
    }
}
