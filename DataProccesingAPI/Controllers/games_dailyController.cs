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
    public class games_dailyController : ControllerBase
    {
        private readonly API_DB_context _context;

        public games_dailyController(API_DB_context context)
        {
            _context = context;
        }

        // GET: api/games_daily
        [HttpGet]
        public async Task<ActionResult<IEnumerable<games_daily>>> Getgames_daily([Required] int page, [Required] int size, string tableName, string tableContent)
        {
            return await _context.games_daily.Skip(page * size).Take(size).ToListAsync();
        }

        // PUT: api/games_daily/5
        [HttpPut("{steamid}")]
        public async Task<IActionResult> Putgames_daily([Required] long steamid, [Required] long appid, games_daily games_daily)
        {
            if (steamid != games_daily.steamid || appid != games_daily.appid)
            {
                return BadRequest("steamid and or appid doesn't match id in body!");
            }

            _context.Entry(games_daily).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!games_dailyExists((int)steamid, (int)appid))
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

        // POST: api/games_daily
        [HttpPost]
        public async Task<ActionResult<games_daily>> Postgames_daily(games_daily games_daily)
        {
            _context.games_daily.Add(games_daily);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgames_daily", new { id = games_daily.steamid }, games_daily);
        }

        // DELETE: api/games_daily/5
        [HttpDelete("{steamid}")]
        public async Task<IActionResult> Deletegames_daily([Required] long steamid, [Required] long appid)
        {
            var games_daily = await _context.games_daily.FindAsync(steamid, appid);
            if (games_daily == null)
            {
                return NotFound();
            }

            _context.games_daily.Remove(games_daily);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool games_dailyExists(int steamid, int appid)
        {
            if (_context.games_daily.Any(e => e.appid == steamid) && _context.games_daily.Any(b => b.appid == appid))
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
