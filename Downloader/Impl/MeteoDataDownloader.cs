using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Downloader.Interfaces;

namespace Downloader.Impl
{
    public class MeteoDataDownloader : IDownloader
    {
        private readonly HttpClient _client;

        public MeteoDataDownloader(HttpClient client)
        {
            _client = client;
        }
        
        public async Task<Stream> DownloadFile(string url)
        {
            return await (await _client.GetAsync(url)).Content.ReadAsStreamAsync();
        }

        public async Task DownloadAndSaveFile(string url, string path)
        {
            using (var streamWithFile = await DownloadFile(url))
            {
                using (var file = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    await streamWithFile.CopyToAsync(file);
                }
            }
        }
    }
}