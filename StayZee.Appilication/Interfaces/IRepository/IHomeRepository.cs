using StayZee.Domain.Entities;

namespace StayZee.Application.Interfaces.IRepository
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Home>> GetAvailableHomesAsync();
        Task<Home> AddHomeAsync(Home home);
        Task<Home?> GetHomeByIdAsync(Guid id);
        Task UpdateHomeAsync(Home home);
        Task DeleteHomeAsync(Guid id);
    }
}
