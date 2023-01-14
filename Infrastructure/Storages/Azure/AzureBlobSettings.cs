using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Storages.Azure
{
    public class AzureBlobSettings
    {
        public string? BlobConnectionString { get; set; }
        public string? BlobContainerName { get; set; }

    }
}
