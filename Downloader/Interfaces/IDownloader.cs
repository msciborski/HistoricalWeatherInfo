using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Downloader.Interfaces
{
    public interface IDownloader
    {
        Task<Stream> DownloadFile(string url);
        Task DownloadAndSaveFile(string url, string path);
    }
}