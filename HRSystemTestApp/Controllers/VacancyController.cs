using HRSystemTestApp.Models;
using HRSystemTestApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRSystemTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _vacancyService;

        public VacancyController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        [HttpGet]
        public async Task<IEnumerable<Vacancy>> GetVacancies()
        {
            return await _vacancyService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vacancy>> GetVacancy(int id)
        {
            return await _vacancyService.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task PutVacancy(int id, Vacancy vacancy)
        {
            await _vacancyService.UpdateAsync(vacancy);
        }

        [HttpPost]
        public async Task PostVacancy(Vacancy vacancy)
        {
            await _vacancyService.CreateAsync(vacancy);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacancy(int id)
        {
            await _vacancyService.DeleteAsync(id);
            return NoContent();
        }
    }
}