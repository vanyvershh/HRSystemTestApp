using HRSystemTestApp.Models;
using HRSystemTestApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRSystemTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            return await _candidateService.GetAllAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidate(int id)
        {
            return await _candidateService.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task PutCandidate(int id, Candidate candidate)
        {
           await _candidateService.UpdateAsync(candidate);
        }

        [HttpPost]
        public async Task PostCandidate(Candidate candidate)
        {
            await _candidateService.CreateAsync(candidate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            await _candidateService.DeleteAsync(id);
            return NoContent();
        }

        //private bool CandidateExists(int id)
        //{
        //    return _context.Candidates.Any(e => e.Id == id);
        //}
        
    }
}