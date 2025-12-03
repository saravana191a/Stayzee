using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using StayZee.Application.Interfaces.Iservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayZee.Infrastructure.Repository
{
    public class CloudService : ICloudService
    {
        private readonly Cloudinary _cloud;

        public CloudService(IConfiguration config)
        {
            var acc = new Account(
                config["Cloudinary:CloudName"],
                config["Cloudinary:ApiKey"],
                config["Cloudinary:ApiSecret"]
            );

            _cloud = new Cloudinary(acc);
        }

        public async Task<List<string>> UploadImagesAsync(List<IFormFile> files)
        {
            List<string> urls = new();

            foreach (var file in files)
            {
                using var stream = file.OpenReadStream();

                var upload = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream)
                };

                var result = await _cloud.UploadAsync(upload);
                urls.Add(result.SecureUrl.ToString());
            }

            return urls;
        }
    }
}

