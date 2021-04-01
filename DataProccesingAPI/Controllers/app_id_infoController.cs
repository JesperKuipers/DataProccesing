using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataProccesingAPI.Models;
using System.Net.Http;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace DataProccesingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class app_id_infoController : ControllerBase
    {
        private readonly API_DB_context _context;

        public app_id_infoController(API_DB_context context)
        {
            _context = context;
        }

        // GET: api/app_id_info?page=0&size=1000
        [HttpGet]
        public async Task<ActionResult<IEnumerable<app_id_info>>> GetAppIdInfo([Required] int page, [Required] int size, string tableName, string tableContent)
        {
            if (tableName == null || tableContent == null)
            {
                return await _context.app_id_info.Skip(page * size).Take(size).ToListAsync();
            }
            else
            {
                var tableNameLowerCase = tableName.ToLower();

                if (tableNameLowerCase == "title")
                {
                    var app_id_info = await _context.app_id_info.Skip(page * size).Take(size).Where(e => e.Title == tableContent).ToListAsync();
                    if (app_id_info.Count == 0)
                    {
                        return NotFound("No data found with the specified data");
                    }
                    return app_id_info;
                }
                else if (tableNameLowerCase == "type")
                {
                    var app_id_info = await _context.app_id_info.Skip(page * size).Take(size).Where(e => e.Type == tableContent).ToListAsync();
                    if (app_id_info.Count == 0)
                    {
                        return NotFound("No data found with the specified data");
                    }
                    return app_id_info;
                }
                else if (tableNameLowerCase == "release_date" || tableNameLowerCase == "releasedate")
                {
                    var app_id_info = await _context.app_id_info.Skip(page * size).Take(size).Where(e => e.Release_Date == DateTime.Parse(tableContent)).ToListAsync();
                    if (app_id_info.Count == 0)
                    {
                        return NotFound("No data found with the specified data");
                    }
                    return app_id_info;
                }
                else if (tableNameLowerCase == "rating")
                {
                    var app_id_info = await _context.app_id_info.Skip(page * size).Take(size).Where(e => e.Rating == Int32.Parse(tableContent)).ToListAsync();
                    if (app_id_info.Count == 0)
                    {
                        return NotFound("No data found with the specified data");
                    }
                    return app_id_info;
                }
                else if (tableNameLowerCase == "required_age" || tableNameLowerCase == "requiredage")
                {
                    var app_id_info = await _context.app_id_info.Skip(page * size).Take(size).Where(e => e.Required_Age == Int32.Parse(tableContent)).ToListAsync();
                    if (app_id_info.Count == 0)
                    {
                        return NotFound("No data found with the specified data");
                    }
                    return app_id_info;
                }
                else if (tableNameLowerCase == "is_multiplayer" || tableNameLowerCase == "ismultiplayer")
                {
                    var app_id_info = await _context.app_id_info.Skip(page * size).Take(size).Where(e => e.Is_Multiplayer == Int16.Parse(tableContent)).ToListAsync();
                    if (app_id_info.Count == 0)
                    {
                        return NotFound("No data found with the specified data");
                    }
                    return app_id_info;
                }
                else if (tableNameLowerCase == "appid")
                {
                    var app_id_info = await _context.app_id_info.Skip(page * size).Take(size).Where(e => e.appid == Int32.Parse(tableContent)).ToListAsync();
                    if (app_id_info.Count == 0)
                    {
                        return NotFound("No data found with the specified data");
                    }
                    return app_id_info;
                }
                else
                {
                    return NotFound("Table doesn't exist in the database!");
                }
            }
        }

        // PUT: api/app_id_info/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putapp_id_info(int id, app_id_info app_id_info)
        {
            if (id != app_id_info.appid)
            {
                return BadRequest("Id doesn't match id in body!");
            }

            _context.Entry(app_id_info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!app_id_infoExists(id))
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

        // POST: api/app_id_info
        [HttpPost]
        public async Task<ActionResult<app_id_info>> Postapp_id_info(app_id_info app_id_info)
        {
            _context.app_id_info.Add(app_id_info);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppIdInfo", new { id = app_id_info.appid }, app_id_info);
        }

        // DELETE: api/app_id_info/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteapp_id_info(int id)
        {
            var app_id_info = await _context.app_id_info.FindAsync(id);
            if (app_id_info == null)
            {
                return NotFound();
            }

            _context.app_id_info.Remove(app_id_info);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool app_id_infoExists(int id)
        {
            return _context.app_id_info.Any(e => e.appid == id);
        }
    }
}
