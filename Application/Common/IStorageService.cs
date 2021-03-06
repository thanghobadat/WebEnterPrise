using System.IO;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace Application.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);

        Task SaveFileAsync(Stream mediaBinaryStream, string fileName);

        Task DeleteFileAsync(string fileName);
        DownloadFileViewModel DownloadZip(string fileName);
    }
}
