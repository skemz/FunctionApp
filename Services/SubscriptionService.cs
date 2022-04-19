using Factory;
using Models;

namespace Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IAzureManagementFactory _azureManagementFactory;
        public SubscriptionService(IAzureManagementFactory azureManagementFactory)
        {
            _azureManagementFactory = azureManagementFactory;
        }

        public async Task<IList<Subscription>> GetAllRepositories()
        {
            var listRepository = new List<Subscription>();
            var armClient = _azureManagementFactory.getAzureClient();
            var subscriptions = armClient.GetSubscriptions().GetAllAsync();
            await foreach (var subscription in subscriptions)
            {
                var temp = new Subscription()
                {
                    SubscriptionId = subscription.Data.Id.Name,
                    SubscriptionName = subscription.Data.DisplayName,
                    Tags = subscription.Data.Tags?.ToDictionary(kv => kv.Key, kv => kv.Value)
                };
                listRepository.Add(temp);
            }
            return listRepository;
        }
    }
}