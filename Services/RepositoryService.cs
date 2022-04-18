using Factory;
using Models;

namespace Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IAzureManagementFactory _azureManagementFactory;
        public RepositoryService(IAzureManagementFactory azureManagementFactory)
        {
            _azureManagementFactory = azureManagementFactory;
        }

        public IEnumerable<Repository> GetAllRepositories()
        {
            var listRepository = new List<Repository>();
            var azureCredentials = _azureManagementFactory.getAzureCredentials();
            var subscriptions = azureCredentials.Subscriptions.List();
            foreach (var subscription in subscriptions)
            {
                listRepository.Add(new Repository() { Id = subscription.SubscriptionId, Name = subscription.DisplayName});
            }
            return listRepository;
        }
    }
}