namespace Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(string id);
        IEnumerator<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}