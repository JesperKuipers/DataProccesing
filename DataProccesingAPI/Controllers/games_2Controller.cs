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
        [HttpPut("{steamid}")]
        public async Task<IActionResult> Putgames_2([Required] long steamid, [Required] long appid, games_2 games_2)
        {
            if (steamid != games_2.steamid || appid != games_2.appid)
            {
                return BadRequest("steamid and or appid doesn't match id in body!");
            }

            _context.Entry(games_2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!games_2Exists((int)steamid, (int)appid))
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
        [HttpPost]
        public async Task<ActionResult<games_2>> Postgames_2(games_2 games_2)
        {
            _context.games_2.Add(games_2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgames_2", new { id = games_2.steamid }, games_2);
        }

        // DELETE: api/games_2/5
        [HttpDelete("{steamid}")]
        public async Task<IActionResult> Deletegames_2([Required] long steamid, [Required] long appid)
        {
            var games_2 = await _context.games_2.FindAsync(steamid, appid);
            if (games_2 == null)
            {
                return NotFound();
            }

            _context.games_2.Remove(games_2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool games_2Exists(int steamid, int appid)
        {
            if (_context.games_2.Any(e => e.appid == steamid) && _context.games_2.Any(b => b.appid == appid))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
