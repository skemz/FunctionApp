using System;
using System.Threading.Tasks;
using Factory;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Models;
using Repositories;
using Services;

namespace FunctionApp1
{
    public class Function1
    {
        private readonly IRepository<ResourceGroup> _resourceGroupRepository;
        private readonly IAzureManagementFactory _azureManagementFactory;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IResourceGroupService _resourceGroupService;
        public Function1(IRepository<ResourceGroup> resourceGroupRepository, ISubscriptionService subscriptionService, IResourceGroupService resourceGroupService)
        {
            _resourceGroupRepository = resourceGroupRepository;
            _subscriptionService     = subscriptionService;
            _resourceGroupService    = resourceGroupService;
        }

        [FunctionName("Function1")]
        public async Task RunAsync([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            //var resource = new ResourceGroup();
            //resource.ResourceGroupId = "1254";
            //_resourceGroupRepository.Add(resource);
            //var azure = _azureManagementFactory.getAzureCredentials();
            var listSubsciptions = await _subscriptionService.GetAllRepositories();

            foreach (var subscription in listSubsciptions)
            {
                subscription.ResourceGroups = await _resourceGroupService.GetAllResourceGroups(subscription.SubscriptionId);
            }

            foreach (var subscription in listSubsciptions)
            {
                log.LogInformation("Subscription");
                log.LogInformation(subscription.SubscriptionId + " " + subscription.SubscriptionName);
                log.LogInformation("=================== List of tags ======================");
                foreach(var tag in subscription.Tags)
                {
                    log.LogInformation(tag.Key + "\t" + tag.Value);
                }
                log.LogInformation("================= End list of tags ====================");
                log.LogInformation("\t================= List of Resource Group ====================");
                foreach(var resourceGroup in subscription.ResourceGroups)
                {
                    log.LogInformation($"\t{ resourceGroup.ResourceGroupName }");
                    if (resourceGroup.Tags != null)
                    {
                        log.LogInformation("\t============= List of tags =================");

                        foreach (var tag in resourceGroup.Tags)
                        {
                            log.LogInformation($"\t{tag.Key}  \t\t {tag.Value} ");
                        }

                        log.LogInformation("\t============ End list of tags ===============");
                    }
                }
            }



        }
    }
}
