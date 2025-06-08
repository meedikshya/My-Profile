namespace ProfileProject.Repository.GenericRepository
{
    public interface IGenericRepositories
    {
        Task<List<T>> SelectAll<T>() where T : class ;
        Task<List<T>> GetById<T>(int id) where T : class;
        Task<List<T>> Insert<T>(T instance) where T : class;
        Task<List<T>> Update<T>(int id, T instance) where T : class;
    }
}
