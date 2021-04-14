using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace AquitoApi.Services
{
    public class CloudinaryService : ICloudinaryService
    {

        public Cloudinary cloudinary;

        public CloudinaryService(IOptions<Account> accountOptions)
        {
            cloudinary = new Cloudinary(accountOptions.Value);
        }

        public async Task<string> FileUpload(string filename, Stream fileStream)
        {


            ImageUploadParams image = new ImageUploadParams
            {
                File = new FileDescription(filename, fileStream),
                UploadPreset = "aquito-web",
                Folder = "aquito-imagenes"
            };

            ImageUploadResult imageUpload = await cloudinary.UploadAsync(image);

            return imageUpload?.SecureUrl?.AbsoluteUri;
        }
    }
}
