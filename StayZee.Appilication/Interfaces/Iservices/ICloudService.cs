using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StayZee.Application.Interfaces.Iservices
{
    public interface ICloudService
    {
        Task<List<string>> UploadImagesAsync(List<IFormFile> files);
    }
}

