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
        public CandidateService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Candidate>> GetAllAsync()
        {
            return await _context.Candidates.ToListAsync();
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
            //_context.Candidates.Add(new Candidate
            //{
            //    Id = 1,
            //    Name = $"Name {1}",
            //    Email = $"Email {1}",
            //    PhoneNumber = $"PhoneNumber {1}",
            //    CVLink = $"CVLink {1}",
            //    RecruitmentStage = $"RecruitmentStage {1}",
            //    ApplicationDate = DateTime.Now,
            //    ProbationaryPeriodEndDate = DateTime.Now
            //});
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
