using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Extensions.Options;
using Models;

namespace Factory
{
    public class AzureManagementFactory : IAzureManagementFactory
    {
        private readonly AzureCredentials _azureCredentials;

        public AzureManagementFactory(IOptions<AzureCredentials> options)
        {
            _azureCredentials = options.Value;
        }

        public IAzure getAzureCredentials()
        {
            var azureCredentials = new AzureCredentials()
            {
                ClientId       = Environment.GetEnvironmentVariable("ClientId")       ?? _azureCredentials.ClientId,
                ClientSecret   = Environment.GetEnvironmentVariable("ClientSecret")   ?? _azureCredentials.ClientSecret,
                TenantId       = Environment.GetEnvironmentVariable("TenantId")       ?? _azureCredentials.TenantId,
                SubscriptionId = Environment.GetEnvironmentVariable("SubscriptionId") ?? _azureCredentials.SubscriptionId
            };


            var azureCredential = SdkContext.AzureCredentialsFactory.FromServicePrincipal(
                                    azureCredentials.ClientId, 
                                    azureCredentials.ClientSecret, 
                                    azureCredentials.TenantId, 
                                    AzureEnvironment.AzureGlobalCloud);
            return Azure
                 .Configure()
                 .Authenticate(azureCredential)
                 .WithSubscription(azureCredentials.SubscriptionId);
        }
    }
}