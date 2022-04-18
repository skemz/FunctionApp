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
        private readonly IRepositoryService _repositoryService;
        public Function1(IRepository<ResourceGroup> resourceGroupRepository, IRepositoryService repositoryService, IAzureManagementFactory azureManagementFactory)
        {
            _resourceGroupRepository = resourceGroupRepository;
            _repositoryService = repositoryService;
        }

        [FunctionName("Function1")]
        public void Run([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            //var resource = new ResourceGroup();
            //resource.ResourceGroupId = "1254";
            //_resourceGroupRepository.Add(resource);
            //var azure = _azureManagementFactory.getAzureCredentials();
            var listSubsciptions = _repositoryService.GetAllRepositories();

            foreach(var item in listSubsciptions)
            {
                Console.WriteLine(item.Id + " " + item.Name);
            }
           
            
        }
    }
}
