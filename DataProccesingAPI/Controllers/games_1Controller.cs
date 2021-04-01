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
    public class games_1Controller : ControllerBase
    {
        private readonly API_DB_context _context;

        public games_1Controller(API_DB_context context)
        {
            _context = context;
        }

        // GET: api/games_1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<games_1>>> Getgames_1([Required] int page, [Required] int size, string tableName, string tableContent)
        {
            return await _context.games_1.Skip(page * size).Take(size).ToListAsync();
        }

        // PUT: api/games_1/5
        [HttpPut("{steamid}")]
        public async Task<IActionResult> Putgames_1([Required] long steamid, [Required] long appid, games_1 games_1)
        {
            if (steamid != games_1.steamid || appid != games_1.appid)
            {
                return BadRequest("steamid and or appid doesn't match id in body!");
            }

            _context.Entry(games_1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!games_1Exists((int)steamid, (int)appid))
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

        // POST: api/games_1
        [HttpPost]
        public async Task<ActionResult<games_1>> Postgames_1(games_1 games_1)
        {
            _context.games_1.Add(games_1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgames_1", new { id = games_1.steamid }, games_1);
        }

        // DELETE: api/games_1/5
        [HttpDelete("{steamid}")]
        public async Task<IActionResult> Deletegames_1([Required] long steamid, [Required] long appid)
        {
            var games_1 = await _context.games_1.FindAsync(steamid, appid);
            if (games_1 == null)
            {
                return NotFound();
            }

            _context.games_1.Remove(games_1);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool games_1Exists(int steamid, int appid)
        {
            if (_context.games_1.Any(e => e.appid == steamid) && _context.games_1.Any(b => b.appid == appid))
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
