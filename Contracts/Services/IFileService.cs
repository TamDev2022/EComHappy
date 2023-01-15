using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IFileService
    {
        public Tuple<bool, string?> IsImageFile(IFormFile file);
        public string GenarateFileNameWebp(string fileName);
        public Task<byte[]> GetFileAsync(string fileName);
        public Task UploadFileAsync(Stream file, string fileName);
        public Task<string> UploadFileAsync(IFormFile file);


    }
}
