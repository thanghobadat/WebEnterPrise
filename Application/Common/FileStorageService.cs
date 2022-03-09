using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace Application.Common
{
    public class FileStorageService : IStorageService
    {
        private readonly string _userContentFolder;
        private const string USER_CONTENT_FOLDER_NAME = "Files";

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _userContentFolder = Path.Combine(webHostEnvironment.WebRootPath, USER_CONTENT_FOLDER_NAME);
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{USER_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        //public DownloadFileViewModel DownloadZip(string fileName)
        //{
        //    var filePath = Path.Combine(_userContentFolder, fileName);
        //    var nameFile = string.Concat(Path.GetFileName(filePath), ".zip");
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        using (var achive = new ZipArchive(memoryStream, ZipArchiveMode.Create))
        //        {
        //            achive.CreateEntryFromFile(filePath, Path.GetFileName(filePath));
        //        }
        //        var fileDownload = new DownloadFileViewModel()
        //        {
        //            FiltType = "aplication/zip",
        //            ArchiveData = memoryStream.ToArray(),
        //            AchiveName = nameFile

        //        };
        //        return fileDownload;
        //    }
        //}
    }
}
