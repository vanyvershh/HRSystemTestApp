using HRSystemTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HRSystemTestApp.Services
{
    public interface ICandidateService
    {
        Task<IEnumerable<Candidate>> GetAllAsync();
        Task<Candidate> GetByIdAsync(int id);
        Task CreateAsync(Candidate candidate);
        Task UpdateAsync(Candidate candidate);
        Task DeleteAsync(int id);
    }

    public class CandidateService : ICandidateService
    {
        private readonly ApplicationDbContext _context;
        public async Task<IEnumerable<Candidate>> GetAllAsync()
        {
            return Enumerable.Range(1, 5).Select(index => new Candidate
            {
                Id = index,
                Name = $"Name {index}",
                Email = $"Email {index}",
                PhoneNumber = $"PhoneNumber {index}",
                CVLink = $"CVLink {index}",
                RecruitmentStage = $"RecruitmentStage {index}",
                ApplicationDate = DateTime.Now,
                ProbationaryPeriodEndDate = DateTime.Now


            });
            //return await _context.Candidates.ToListAsync();

        }
        public async Task<Candidate> GetByIdAsync(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);

            if (candidate == null)
            {
                return null;
            }

            return candidate;
        }
        public async Task CreateAsync(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Candidate candidate)
        {
            _context.Entry(candidate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
