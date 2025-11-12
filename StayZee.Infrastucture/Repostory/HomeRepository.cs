using Microsoft.EntityFrameworkCore;
using StayZee.Application.Interfaces.IRepository;
using StayZee.Domain.Entities;
using StayZee.Infrastructure.Data;

namespace StayZee.Infrastructure.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly AppDbContext _context;

        public HomeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Home>> GetAvailableHomesAsync()
        {
            var today = DateTime.UtcNow;
            return await _context.Homes
                .Include(h => h.HomeApprovalStatus)
                .Where(h => h.HomeApprovalStatus.Name == "Approved"
                            && h.AvailableFrom <= today
                            && h.AvailableTo >= today)
                .ToListAsync();
        }

        public async Task<Home> AddHomeAsync(Home home)
        {
            home.Id = Guid.NewGuid();
            _context.Homes.Add(home);
            await _context.SaveChangesAsync();
            return home;
        }

        public async Task<Home?> GetHomeByIdAsync(Guid id)
        {
            return await _context.Homes
                .Include(h => h.HomeApprovalStatus)
                .Include(h => h.Bookings)
                .Include(h => h.Documents)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task UpdateHomeAsync(Home home)
        {
            _context.Homes.Update(home);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHomeAsync(Guid id)
        {
            var home = await _context.Homes.FindAsync(id);
            if (home != null)
            {
                _context.Homes.Remove(home);
                await _context.SaveChangesAsync();
            }
        }
    }
}
