using Models;

namespace Services
{
    public interface IResourceGroupService
    {
        Task<IList<ResourceGroup>> GetAllResourceGroups(string subscriptionId);
    }
}
