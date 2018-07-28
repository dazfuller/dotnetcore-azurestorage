using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace dotnetblob
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            
            var demo = new StorageDemo(config);
            await demo.Run();
        }
    }

    public class StorageDemo
    {
        private IConfigurationRoot _config;

        public StorageDemo(IConfigurationRoot config)
        {
            _config = config;
        }

        public async Task Run()
        {
            var credentials = new StorageCredentials(_config["Storage:Name"], _config["Storage:Key"]);
            var storageAccount = new CloudStorageAccount(credentials, useHttps: true);
            var blobClient = storageAccount.CreateCloudBlobClient();

            var container = blobClient.GetContainerReference(_config["Storage:Container"]);
            if (!await container.ExistsAsync())
            {
                await container.CreateAsync();
            }

            var blob = container.GetBlockBlobReference("demo_file.txt");
            await blob.DeleteIfExistsAsync();

            var demoText = "This is some sample text to go into our new blob";
            using (var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(demoText)))
            {
                using (var blobOutputStream = await blob.OpenWriteAsync())
                {
                    inputStream.CopyTo(blobOutputStream);
                }
            }
        }
    }
}
