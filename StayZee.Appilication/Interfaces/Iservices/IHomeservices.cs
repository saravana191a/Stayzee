using StayZee.Domain.Entities;

namespace StayZee.Application.Interfaces.IServices
{
    public interface IHomeService
    {
        Task<IEnumerable<Home>> GetAvailableHomesAsync();
        Task<Home> AddHomeAsync(Home home);
        Task<Home?> GetHomeByIdAsync(Guid id);
        Task UpdateHomeAsync(Home home);
        Task DeleteHomeAsync(Guid id);
    }
}
