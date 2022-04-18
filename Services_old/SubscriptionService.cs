using Microsoft.Extensions.Configuration;
using Models;

namespace Services
{
    public class SubscriptionService
    {
        private IConfiguration _configuration;
        private Subscription? subscription = null;
        
        public SubscriptionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void InitializeSubscription(string subscriptionId, string subscriptionName)
        {
            subscription = new Subscription() { SubscriptionId = subscriptionId, SubscriptionName = subscriptionName, resourceGroups = new List<ResourceGroup>};
        }

        public Subscription? getSubscription()
        {
            return subscription;
        }
    }
}