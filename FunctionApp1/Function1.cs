using System;
using Factory;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Models;
using Repositories;

namespace FunctionApp1
{
    public class Function1
    {
        private readonly IRepository<ResourceGroup> _resourceGroupRepository;
        private readonly AzureCredentialsFactory _azureCredentialsFactory;
        public Function1(IRepository<ResourceGroup> resourceGroupRepository, AzureCredentialsFactory azureCredentialsFactory)
        {
            _resourceGroupRepository = resourceGroupRepository;
            _azureCredentialsFactory = azureCredentialsFactory;
        }

        [FunctionName("Function1")]
        public void Run([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            //var resource = new ResourceGroup();
            //resource.ResourceGroupId = "1254";
            //_resourceGroupRepository.Add(resource);
            var azureCredentials = _azureCredentialsFactory.getAzureCredentials();
            
        }
    }
}
