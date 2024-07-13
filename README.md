# Project Overview

## Application for Accessing Secrets via Azure App Configuration

This application connects with Azure App Configuration and retrieves key-value references. These references allow the application to fetch secrets from which they are referenced in Azure Key Vaults.

### App Configuration

The application uses Azure App Configuration to manage configuration settings, including references to secrets stored in Azure Key Vault. Here’s a snapshot of how the App Configuration is set up:

![App Configuration](https://github.com/user-attachments/assets/93845d6e-d7aa-40f6-8a21-cbe522404e70)

### Key Vault

The secrets referenced in Azure App Configuration are securely stored in Azure Key Vault. Here’s a snapshot of the Key Vault setup:

![Key Vault](https://github.com/user-attachments/assets/cacfcd96-7024-4514-95b2-e33909a983ce)

### How It Works

1. **Configuration Setup:**
   - Azure Key Vault stores secrets.
   - Azure App Configuration stores key-value pairs where values can reference secrets in Azure Key Vault.

2. **Application Initialization:**
   - The application connects to Azure App Configuration using `DefaultAzureCredential`.
   - Key-value pairs from App Configuration are loaded into the application's configuration.

3. **Secret Access:**
   - The application retrieves secrets from Azure Key Vault via the references defined in Azure App Configuration.



**Install the necessary NuGet packages:**
```bash
dotnet add package Microsoft.Extensions.Configuration.AzureAppConfiguration
dotnet add package Azure.Identity

