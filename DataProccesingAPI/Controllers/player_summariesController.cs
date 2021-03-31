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
    public class player_summariesController : ControllerBase
    {
        private readonly API_DB_context _context;

        public player_summariesController(API_DB_context context)
        {
            _context = context;
        }

        // GET: api/player_summaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<player_summaries>>> Getplayer_summaries([Required] int page, [Required] int size, string tableName, string tableContent)
        {
            return await _context.player_summaries.Skip(page * size).Take(size).ToListAsync();
        }

        // PUT: api/player_summaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putplayer_summaries(long id, player_summaries player_summaries)
        {
            if (id != player_summaries.steamid)
            {
                return BadRequest("Id doesn't match id in body!");
            }

            _context.Entry(player_summaries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!player_summariesExists(id))
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

        // POST: api/player_summaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<player_summaries>> Postplayer_summaries(player_summaries player_summaries)
        {
            _context.player_summaries.Add(player_summaries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getplayer_summaries", new { id = player_summaries.steamid }, player_summaries);
        }

        // DELETE: api/player_summaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteplayer_summaries(long id)
        {
            var player_summaries = await _context.player_summaries.FindAsync(id);
            if (player_summaries == null)
            {
                return NotFound();
            }

            _context.player_summaries.Remove(player_summaries);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool player_summariesExists(long id)
        {
            return _context.player_summaries.Any(e => e.steamid == id);
        }
    }
}
