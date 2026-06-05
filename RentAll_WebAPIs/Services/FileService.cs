namespace RentAll_WebAPIs.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadsFolder, uniqueName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/uploads/{uniqueName}";
        }

        public void DeleteFile(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl)) return;

            var filePath = Path.Combine(_env.WebRootPath, imageUrl.TrimStart('/'));
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}



