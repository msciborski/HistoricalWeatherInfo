using System.IO;
using FileService.Interfaces;

namespace FileService.Impl
{
    public class FileService : IFileService
    {
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}