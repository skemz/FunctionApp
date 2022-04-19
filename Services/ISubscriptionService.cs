using Models;

namespace Services
{
    public interface ISubscriptionService
    {
        Task<IList<Subscription>> GetAllRepositories();
    }
}
