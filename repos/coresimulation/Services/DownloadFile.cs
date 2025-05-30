using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;

namespace coresimulation.Services
{
    public class DownloadFile
    {
        public (byte[] fileData, string contentType, string fileName)? Download(string filename)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", filename);

            if (!File.Exists(filePath))
                return null;

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var fileBytes = File.ReadAllBytes(filePath);
            return (fileBytes, contentType, filename);
        }
    }
}
