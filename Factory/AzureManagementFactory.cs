using Azure.Identity;
using Azure.ResourceManager;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Extensions.Options;
using Models;
using System.Linq;

namespace Factory
{
    public class AzureManagementFactory : IAzureManagementFactory
    {
        private readonly AzureCredentials _azureCredentials;

        public AzureManagementFactory(IOptions<AzureCredentials> options)
        {
            _azureCredentials = options.Value;
        }

        public ArmClient getAzureClient()
        {
            var azureCredentials = new AzureCredentials()
            {
                ClientId       = Environment.GetEnvironmentVariable("ClientId")       ?? _azureCredentials.ClientId,
                ClientSecret   = Environment.GetEnvironmentVariable("ClientSecret")   ?? _azureCredentials.ClientSecret,
                TenantId       = Environment.GetEnvironmentVariable("TenantId")       ?? _azureCredentials.TenantId,
                SubscriptionId = Environment.GetEnvironmentVariable("SubscriptionId") ?? _azureCredentials.SubscriptionId
            };

            //var environementCredentials = new EnvironmentCredential(new TokenCredentialOptions());
            var clientSecretCredentials = new ClientSecretCredential(azureCredentials.TenantId,azureCredentials.ClientId,azureCredentials.ClientSecret);
            return new ArmClient(clientSecretCredentials);

        }
    }
}