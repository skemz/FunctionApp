using Microsoft.Extensions.Options;
using Models;

namespace Factory
{
    public class AzureCredentialsFactory
    {
        private readonly AzureCredentials _azureCredentials;

        public AzureCredentialsFactory(IOptions<AzureCredentials> options)
        {
            _azureCredentials = options.Value;
        }

        public AzureCredentials getAzureCredentials()
        {
            if (_azureCredentials == null)
            {
                return new AzureCredentials() 
                { 
                    ClientId = Environment.GetEnvironmentVariable("ClientId") ?? "", 
                    ClientSecret = Environment.GetEnvironmentVariable("ClientSecret") ?? "", 
                    TenantId = Environment.GetEnvironmentVariable("TenantId") ?? "" 
                };
            }
            return _azureCredentials;
        }
    }
}