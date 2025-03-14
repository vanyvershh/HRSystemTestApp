using HRSystemTestApp.Models;
using HRSystemTestApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRSystemTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRController : ControllerBase
    {
        private readonly IHRService _hrService;

        public HRController(IHRService hrService)
        {
            _hrService = hrService;
        }

        [HttpGet]
        public async Task<IEnumerable<HR>> GetHRs()
        {
            return await _hrService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HR>> GetHR(int id)
        {
            return await _hrService.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task PutHR(int id, HR candidate)
        {
            await _hrService.UpdateAsync(candidate);
        }

        [HttpPost]
        public async Task PostHR(HR candidate)
        {
            await _hrService.CreateAsync(candidate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHR(int id)
        {
            await _hrService.DeleteAsync(id);
            return NoContent();
        }
    }
}