using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StayZee.Application.Interfaces.IRepository;
using StayZee.Infrastructure.Data;
using StayZee.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StayZee.Infrastructure.Repostory
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly AppDbContext _db;

        public PropertyRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Property property)
        {
            await _db.Properties.AddAsync(property);
            await _db.SaveChangesAsync();
        }

        public Task AddAsync(Microsoft.EntityFrameworkCore.Metadata.Internal.Property p)
        {
            throw new NotImplementedException();
        }

        public async Task<Property?> GetByIdAsync(Guid id)
        {
            return await _db.Properties.FindAsync(id);
        }

        public async Task<List<Property>> GetPropertiesAsync(string? search, string? city, int? minBedrooms, decimal? maxPrice,
            bool? isLongTerm, string? propertyType, bool? furnished, bool? wifi, bool? petFriendly, bool? parking)
        {
            var q = _db.Properties.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                q = q.Where(p => p.Title.Contains(search) || p.Description.Contains(search));

            if (!string.IsNullOrWhiteSpace(city))
                q = q.Where(p => p.City == city);

            if (minBedrooms.HasValue)
                q = q.Where(p => p.MinBedrooms >= minBedrooms.Value);

            if (maxPrice.HasValue)
                q = q.Where(p => p.DayPrice <= maxPrice.Value);

            if (isLongTerm.HasValue)
                q = q.Where(p => p.IsLongTerm == isLongTerm.Value);

            if (!string.IsNullOrWhiteSpace(propertyType))
                q = q.Where(p => p.PropertyType == propertyType);

            if (furnished == true)
                q = q.Where(p => p.IsFurnished);

            if (wifi == true)
                q = q.Where(p => p.HasWifi);

            if (petFriendly == true)
                q = q.Where(p => p.IsPetFriendly);

            if (parking == true)
                q = q.Where(p => p.HasParking);

            return await q.OrderBy(p => p.DayPrice).ToListAsync();
        }

        public Task<List<Microsoft.EntityFrameworkCore.Metadata.Internal.Property>> GetPropertyAsync(string? search, string? city, int? minBedrooms, decimal? maxPrice, bool? isLongTerm, string? propertyType, bool? furnished, bool? wifi, bool? petFriendly, bool? parking)
        {
            throw new NotImplementedException();
        }

        public async Task SeedAsync()
        {
            if (await _db.Properties.AnyAsync()) return;

            var sample = new List<Property>
            {
                new Property
                {
                    Title = "Modern Apartment in Colombo",
                    Description = "A stylish 2BHK with sea view",
                    City = "Colombo",
                    MinBedrooms = 2,
                    DayPrice = 4500,
                    IsFurnished = true,
                    HasWifi = true,
                    HasParking = true,
                    PropertyType = "Apartment",
                    IsLongTerm = true,
                    ImageUrl = ""
                },
                new Property
                {
                    Title = "Budget Friendly Studio",
                    Description = "Perfect for students",
                    City = "Kandy",
                    MinBedrooms = 1,
                    DayPrice = 3000,
                    IsFurnished = false,
                    HasWifi = true,
                    PropertyType = "Studio",
                    IsLongTerm = false,
                    ImageUrl = ""
                }
            };

            await _db.Properties.AddRangeAsync(sample);
            await _db.SaveChangesAsync();
        }

        Task<Microsoft.EntityFrameworkCore.Metadata.Internal.Property?> IPropertyRepository.GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<List<Microsoft.EntityFrameworkCore.Metadata.Internal.Property>> IPropertyRepository.GetPropertiesAsync(string? search, string? city, int? minBedrooms, decimal? maxPrice, bool? isLongTerm, string? propertyType, bool? furnished, bool? wifi, bool? petFriendly, bool? parking)
        {
            throw new NotImplementedException();
        }
    }
}
