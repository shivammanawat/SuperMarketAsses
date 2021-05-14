using Azure.Storage.Blobs;
using Supermarket_WebApi.Models;
using System.Threading.Tasks;

namespace Supermarket_WebApi.Service
{
    public class FileManager : IFileManager
    { 
        private readonly BlobServiceClient _blobServiceClient;
        public FileManager(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task Upload(FileModel model)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("fileuploadcontainer");

            var blobClient = blobContainer.GetBlobClient(model.ImageFile.FileName);

            await blobClient.UploadAsync(model.ImageFile.OpenReadStream());
        }



    }
}
