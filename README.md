# DotNetCore - Azure Storage Demo

This is a sample application showing how you can use [dotnet core](https://dotnet.github.io/) to write data to [Azure Storage](https://docs.microsoft.com/azure/storage/) using blobs. The repository was created for the Elastacloud channels post [DotNetCore and Azure Storage](https://www.channels.elastacloud.com/channels/software-engineering/dotnetcore-and-azure-storage).

To use the application you will need to create an `appsettings.json` file in the root with the following structure.

```json
{
    "Storage": {
        "Name": "<Name of the Storage Account>",
        "Key": "<Storage key>",
        "Container": "<container name>"
    }
}
```

Such as:

```json
{
    "Storage": {
        "Name": "dotnetcoredemo",
        "Key": "54cO0hPm5U6o2RA2exxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx==",
        "Container": "demo"
    }
}
```

You can get these values using Powershell, Azure CLI or the Azure Portal.
