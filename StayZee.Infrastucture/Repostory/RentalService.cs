using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StayZee.Application.DTOs.ResponseDTO;
using StayZee.Application.DTOs.RequestDTO;
using StayZee.Application.Interfaces.Iservices;
using StayZee.Domain.Entities;
using StayZee.Infrastructure.Data;

namespace StayZee.Infrastructure.Repository
{
    public class RentalService : IRentalService
    {
        private readonly AppDbContext _context;
        private readonly ICloudService _cloud;

        public RentalService(AppDbContext context, ICloudService cloud)
        {
            _context = context;
            _cloud = cloud;
        }

        public async Task<RentalResponse> CreateRental(CreateRentalRequest request)
        {
            if (request.Photos.Count < 4)
                throw new Exception("Minimum 4 photos required");

            var urls = await _cloud.UploadImagesAsync(request.Photos);

            var rental = new Rental
            {
                UserId = request.UserId,
                AccountNumber = request.AccountNumber,
                HomeLocation = request.HomeLocation,
                OneDayPrice = request.OneDayPrice,
                CurrentBill = request.CurrentBill,

                PhotoUrl1 = urls[0],
                PhotoUrl2 = urls[1],
                PhotoUrl3 = urls[2],
                PhotoUrl4 = urls[3]
            };

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            return new RentalResponse
            {
                RentalId = rental.Id,
                Message = "Rental Created Successfully"
            };
        }
    }
}
