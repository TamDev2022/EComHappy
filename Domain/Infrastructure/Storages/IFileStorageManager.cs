using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Storages
{
    public interface IFileStorageManager
    {
        public Task<BlobResponse> DeleteAsync(string blobFilename);

        public Task<BlobResponse?> UploadAsync(IFormFile file);

        public Task<BlobFile> DownloadAsync(string blobFilename);

        public Task<List<BlobFile>> ListAsync();
    }

    public class BlobResponse
    {
        public string? Message { get; set; }
        public bool Error { get; set; }
        public BlobFile BlobFile { get; set; }

        public BlobResponse()
        {
            BlobFile = new BlobFile();
        }
    }

    public class BlobFile
    {
        public string? Uri { get; set; }
        public string? Name { get; set; }
        public string? ContentType { get; set; }
        public Stream? Content { get; set; }
    }

    public interface IFileEntry
    {
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public string FileLocation { get; set; }
    }


}

