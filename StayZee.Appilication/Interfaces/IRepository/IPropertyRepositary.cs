using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StayZee.Application.Interfaces.IRepository
{
    public interface IPropertyRepository
    {
        Task<List<Property>> GetPropertiesAsync(string? search, string? city, int? minBedrooms, decimal? maxPrice,
           bool? isLongTerm, string? propertyType, bool? furnished, bool? wifi, bool? petFriendly, bool? parking);

        Task<Property?> GetByIdAsync(Guid id);
        Task AddAsync(Property p);
        Task SeedAsync();
        Task<List<Property>> GetPropertyAsync(string? search, string? city, int? minBedrooms, decimal? maxPrice, bool? isLongTerm, string? propertyType, bool? furnished, bool? wifi, bool? petFriendly, bool? parking);
    }

}
