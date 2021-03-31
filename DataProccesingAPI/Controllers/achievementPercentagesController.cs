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
    public class achievementPercentagesController : ControllerBase
    {
        private readonly API_DB_context _context;

        public achievementPercentagesController(API_DB_context context)
        {
            _context = context;
        }

        // GET: api/achievementPercentages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<achievement_percentages>>> GetAchievementPercentages([Required] int page, [Required] int size, string tableName, string tableContent)
        {
            if (tableName == null || tableContent == null)
            {
                return await _context.achievement_percentages.Skip(page * size).Take(size).ToListAsync();
            }
            else
            {
                var tableNameLowerCase = tableName.ToLower();

                if (tableNameLowerCase == "appid")
                {
                    var achievement_percentages = await _context.achievement_percentages.Skip(page * size).Take(size).Where(e => e.appid == Int32.Parse(tableContent)).ToListAsync();
                    if (achievement_percentages.Count == 0)
                    {
                        return NotFound("No data found with the specified data");
                    }
                    return achievement_percentages;
                }
                else if (tableNameLowerCase == "name")
                {
                    var achievement_percentages = await _context.achievement_percentages.Skip(page * size).Take(size).Where(e => e.Name == tableContent).ToListAsync();
                    if (achievement_percentages.Count == 0)
                    {
                        return NotFound("No data found with the specified data");
                    }
                    return achievement_percentages;
                }
                else if (tableNameLowerCase == "percentage")
                {
                    var achievement_percentages = await _context.achievement_percentages.Skip(page * size).Take(size).Where(e => e.Percentage == float.Parse(tableContent)).ToListAsync();
                    if (achievement_percentages.Count == 0)
                    {
                        return NotFound("No data found with the specified data");
                    }
                    return achievement_percentages;
                }
                else
                {
                    return NotFound("Table doesn't exist in the database!");
                }
            }
        }

        // PUT: api/achievementPercentages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putachievement_percentages([Required] long id, [Required] string name, achievement_percentages achievement_percentages)
        {
            if (id != achievement_percentages.appid || name != achievement_percentages.Name)
            {
                return BadRequest("Id or Name doesn't match in the body!");
            }

            _context.Entry(achievement_percentages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!achievement_percentagesExists((int)id, name))
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

        // POST: api/achievementPercentages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<achievement_percentages>> Postachievement_percentages(achievement_percentages achievement_percentages)
        {
            _context.achievement_percentages.Add(achievement_percentages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAchievementPercentages", new { id = achievement_percentages.appid }, achievement_percentages);
        }

        // DELETE: api/achievementPercentages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteachievement_percentages([Required] long id, [Required] string name)
        {
            var achievement_percentages = await _context.achievement_percentages.FindAsync(id, name);
            if (achievement_percentages == null)
            {
                return NotFound();
            }

            _context.achievement_percentages.Remove(achievement_percentages);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool achievement_percentagesExists(int id, string name)
        {
            if (_context.achievement_percentages.Any(e => e.appid == id) && _context.achievement_percentages.Any(b => b.Name == name))
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
