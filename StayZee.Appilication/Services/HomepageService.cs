using StayZee.Application.DTOs.ResponseDTO;
using StayZee.Application.Interfaces;
using StayZee.Domain.Entities;

namespace StayZee.Application.Services
{
    public class HomepageService
    {
        private readonly IHomeRepository _homeRepo;

        public HomepageService(IHomeRepository homeRepo)
        {
            _homeRepo = homeRepo;
        }

        public async Task<IEnumerable<HomepageDto>> GetHomepageHomesAsync()
        {
            var homes = await _homeRepo.GetAllAsync();
            var approvedHomes = homes.Where(h => h.HomeApprovalStatus != null && h.HomeApprovalStatus.Name == "Approved");

            return approvedHomes.Select(h => new HomepageDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                ImagePath = h.ImagePath,
                RatePerDay = h.RatePerDay,
                Features = h.Features
            });
        }
    }
}
