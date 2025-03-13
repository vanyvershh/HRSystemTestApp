using HRSystemTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRSystemTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HRController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HRs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HR>>> GetHRs()
        {
            return await _context.HRs.ToListAsync();
        }

        // GET: api/HRs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HR>> GetHR(int id)
        {
            var hr = await _context.HRs.FindAsync(id);

            if (hr == null)
            {
                return NotFound();
            }

            return hr;
        }

        // PUT: api/HRs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHR(int id, HR hr)
        {
            if (id != hr.Id)
            {
                return BadRequest();
            }

            _context.Entry(hr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HRExists(id))
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

        // POST: api/HRs
        [HttpPost]
        public async Task<ActionResult<HR>> PostHR(HR hr)
        {
            _context.HRs.Add(hr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHR", new { id = hr.Id }, hr);
        }

        // DELETE: api/HRs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHR(int id)
        {
            var hr = await _context.HRs.FindAsync(id);
            if (hr == null)
            {
                return NotFound();
            }

            _context.HRs.Remove(hr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HRExists(int id)
        {
            return _context.HRs.Any(e => e.Id == id);
        }
    }
}