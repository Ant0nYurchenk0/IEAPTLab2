using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IEAPTLab2.Models;

namespace IEAPTLab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
        private readonly RestaurantAPIContext _context;

        public SeasonsController(RestaurantAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = _context.Seasons;
            return Ok(items);
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,StartDate, EndDate, Description")] Season Season)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(Season);
                await _context.SaveChangesAsync();
                return Ok(Season);
            }
            return BadRequest(Season);
        }
        [HttpPut]
        public async Task<IActionResult> Edit([Bind("Id, Name,StartDate, EndDate, Description")] Season Season)
        {
            if (ModelState.IsValid)
            {
                if (SeasonExists(Season.Id))
                {
                    _context.Update(Season);
                    await _context.SaveChangesAsync();
                    return Ok(Season);
                }
                return NotFound();
            }
            return BadRequest(Season);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete( int id)
        {
            Console.WriteLine(id);
            if (!SeasonExists(id))
            {
                return NotFound();
            }
            var Season = await _context.Seasons.FirstAsync(m => m.Id == id);
            _context.Seasons.Remove(Season);
            await _context.SaveChangesAsync();
            return Ok(Season);
        }
        private bool SeasonExists(int id)
        {
            return (_context.Seasons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
