using Microsoft.AspNetCore.Components.Forms;

namespace Blazor_Casa_Imoveis.Services
{
    public class UpFileService : IUpFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public UpFileService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }
        public bool DeleteFile(string fileName)
        {
            try
            {
                var path = $"{_webHostEnvironment.WebRootPath}\\ImovelImages\\{fileName}";
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpFile(IBrowserFile file)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(file.Name);
                var filename = Guid.NewGuid().ToString() + fileInfo.Extension;
                var folder = $"{_webHostEnvironment.WebRootPath}\\ImovelImages";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "ImovelImages" , filename);
                var memoryStream = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(memoryStream);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                await using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.WriteTo(fs);
                }
                var url = $"{_configuration.GetValue<string>("ServerUrl")}";
                var fulPath = $"{url}ImovelImages/{filename}";
                return fulPath;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
