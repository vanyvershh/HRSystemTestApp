using HRSystemTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HRSystemTestApp.Services
{
    public interface IVacancyService
    {
        Task<IEnumerable<Vacancy>> GetAllAsync();
        Task<Vacancy> GetByIdAsync(int id);
        Task CreateAsync(Vacancy vacancy);
        Task UpdateAsync(Vacancy vacancy);
        Task DeleteAsync(int id);
    }

    public class VacancyService : IVacancyService
    {
        private readonly ApplicationDbContext _context;
        public VacancyService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Vacancy>> GetAllAsync()
        {
            return await _context.Vacancies.ToListAsync();
        }
        public async Task<Vacancy> GetByIdAsync(int id)
        {
            var vacancy = await _context.Vacancies.FindAsync(id);

            if (vacancy == null)
            {
                return null;
            }

            return vacancy;
        }
        public async Task CreateAsync(Vacancy vacancy)
        {
            _context.Vacancies.Add(vacancy);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vacancy vacancy)
        {
            _context.Entry(vacancy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var vacancy = await _context.Vacancies.FindAsync(id);
            if (vacancy != null)
            {
                _context.Vacancies.Remove(vacancy);
                await _context.SaveChangesAsync();
            }
        }
    }
}
