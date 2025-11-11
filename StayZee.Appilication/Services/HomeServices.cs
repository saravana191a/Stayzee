using StayZee.Application.Interfaces.IServices;
using StayZee.Application.Interfaces.IRepository;
using StayZee.Domain.Entities;

namespace StayZee.Application.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepo;

        public HomeService(IHomeRepository homeRepo)
        {
            _homeRepo = homeRepo;
        }

        public Task<IEnumerable<Home>> GetAvailableHomesAsync() => _homeRepo.GetAvailableHomesAsync();
        public Task<Home> AddHomeAsync(Home home) => _homeRepo.AddHomeAsync(home);
        public Task<Home?> GetHomeByIdAsync(Guid id) => _homeRepo.GetHomeByIdAsync(id);
        public Task UpdateHomeAsync(Home home) => _homeRepo.UpdateHomeAsync(home);
        public Task DeleteHomeAsync(Guid id) => _homeRepo.DeleteHomeAsync(id);
    }
}
