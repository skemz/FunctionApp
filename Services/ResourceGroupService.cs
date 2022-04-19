using Azure.ResourceManager.Resources;
using Factory;
using Microsoft.Extensions.Logging;
using Models;

namespace Services
{
    public class ResourceGroupService : IResourceGroupService
    {
        private readonly IAzureManagementFactory _azureManagementFactory;


        public ResourceGroupService(IAzureManagementFactory azureManagementFactory)
        {
            _azureManagementFactory = azureManagementFactory;

        }

        public async Task<IList<ResourceGroup>> GetAllResourceGroups(string subscriptionId)
        {
            List<ResourceGroup> listResourceGroups = new List<ResourceGroup>();
            var azureClient = _azureManagementFactory.getAzureClient();
            var subscriptionResource = azureClient.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(subscriptionId));
            var resources = subscriptionResource.GetResourceGroups().GetAllAsync();
            await foreach(var resourceGroup in resources)
            {
                if (resourceGroup != null)
                {
                    var rg = new ResourceGroup()
                    {
                        ResourceGroupName = resourceGroup.Data.Name,
                        Tags = resourceGroup.Data.Tags?.ToDictionary(kv => kv.Key, kv => kv.Value)
                    };
                    listResourceGroups.Add(rg);
                }
            }
            return listResourceGroups;
        }
    }
}
