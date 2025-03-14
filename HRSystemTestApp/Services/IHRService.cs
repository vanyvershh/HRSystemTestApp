using HRSystemTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HRSystemTestApp.Services
{
    public interface IHRService
    {
        Task<IEnumerable<HR>> GetAllAsync();
        Task<HR> GetByIdAsync(int id);
        Task CreateAsync(HR hr);
        Task UpdateAsync(HR hr);
        Task DeleteAsync(int id);
    }

    public class HRService : IHRService
    {
        private readonly ApplicationDbContext _context;
        public HRService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<HR>> GetAllAsync()
        {
            return await _context.HRs.ToListAsync();
        }
        public async Task<HR> GetByIdAsync(int id)
        {
            var hr = await _context.HRs.FindAsync(id);

            if (hr == null)
            {
                return null;
            }

            return hr;
        }
        public async Task CreateAsync(HR hr)
        {
            _context.HRs.Add(hr);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HR hr)
        {
            _context.Entry(hr).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hr = await _context.HRs.FindAsync(id);
            if (hr != null)
            {
                _context.HRs.Remove(hr);
                await _context.SaveChangesAsync();
            }
        }
    }
}
