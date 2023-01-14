using Application.DTOs;
using Application.Service;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Domain.Infrastructure.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Storages.Azure
{
    public class AzureBlobStorageManager : IFileStorageManager
    {
        private readonly FileService _fileService;

        private readonly AzureBlobSettings _option;
        private readonly BlobContainerClient _container;

        public AzureBlobStorageManager(AzureBlobSettings option, FileService fileService)
        {
            _option = option;
            _fileService = fileService;
            _container = new BlobContainerClient(_option.BlobConnectionString, _option.BlobContainerName);
        }

        private string GetBlobName(IFileEntry fileEntry)
        {
            return fileEntry.FileLocation;
        }

        public Task<BlobResponse?> DeleteAsync(string blobFilename)
        {
            throw new NotImplementedException();
        }

        public async Task<BlobFile?> DownloadAsync(string blobFilename)
        {
            try
            {
                // Get a reference to the blob uploaded earlier from the API in the container from configuration settings
                BlobClient file = _container.GetBlobClient(blobFilename);

                // Check if the file exists in the container
                if (await file.ExistsAsync())
                {
                    var data = await file.OpenReadAsync();
                    Stream blobContent = data;

                    // Download the file details async
                    var content = await file.DownloadContentAsync();

                    // Add data to variables in order to return a BlobFile
                    string name = blobFilename;
                    string contentType = content.Value.Details.ContentType;

                    // Create new BlobFile with blob data from variables
                    return new BlobFile { Content = blobContent, Name = name, ContentType = contentType };
                }
            }
            catch (RequestFailedException ex)
                when (ex.ErrorCode == BlobErrorCode.BlobNotFound)

            {

            }

            // File does not exist, return null and handle that in requesting method
            return null;
        }

        public async Task<List<BlobFile>> ListAsync()
        {

            // Create a new list object for 
            List<BlobFile> files = new List<BlobFile>();

            await foreach (BlobItem file in _container.GetBlobsAsync())
            {
                // Add each file retrieved from the storage container to the files list by creating a BlobDto object
                string uri = _container.Uri.ToString();
                var name = file.Name;
                var fullUri = $"{uri}/{name}";

                files.Add(new BlobFile
                {
                    Uri = fullUri,
                    Name = name,
                    ContentType = file.Properties.ContentType
                });
            }

            // Return all files to the requesting method
            return files;
        }

        public async Task<BlobResponse?> UploadAsync(IFormFile file)
        {
            BlobResponse response = new();

            try
            {
                var NewFileName = _fileService.GenarateFileNameWebp(file.FileName);

                // Get a reference to the blob just uploaded from the API in a container from configuration settings
                BlobClient client = _container.GetBlobClient(NewFileName);

                // Open a stream for the file we want to upload
                await using (Stream? data = file.OpenReadStream())
                {
                    // Upload the file async
                    await client.UploadAsync(data);
                }

                // Everything is OK and file got uploaded
                response.Message = $"File {NewFileName} Uploaded Successfully";
                response.Error = false;
                response.BlobFile.Uri = client.Uri.AbsoluteUri;
                response.BlobFile.Name = client.Name;
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobAlreadyExists)
            {
                response.Message = $"File with name {file.FileName} already exists. Please use another name to store your file.";
                response.Error = true;
                return response;
            }
            // If we get an unexpected error, we catch it here and return the error message
            catch (RequestFailedException ex)
            {
                // Log error to console and create a new response we can return to the requesting method
                response.Message = $"Unexpected error: {ex.StackTrace}. Check log with StackTrace ID.";
                response.Error = true;
                return response;
            }
            return response;
        }
    }
}
