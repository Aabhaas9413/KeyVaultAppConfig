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


**Refresh app config specific keys:**
The options.ConfigureRefresh method in Azure App Configuration is used to set up automatic refresh of configuration values. This allows your application to periodically check for and apply updates to specific configuration keys without requiring a restart.

### Example Calculation

Assume you have one instance of your application.
Each minute, it makes one request to check the `TestApp:Settings:UseSampleKey` value.
This totals to:
1 request per minute × 60 minutes per hour × 24 hours per day = 1,440 requests per day.

For a month (~30 days), this would be:

1,440 requests/day × 30 days = 43,200 requests per month.

Given the Azure App Configuration pricing (as of my last knowledge update in July 2023):

**Standard Tier Pricing**: $1.50 per 100,000 requests.

**Cost for 43,200 requests per month**:
(43,200 / 100,000) × 1.50 = $0.648 per month per instance.
