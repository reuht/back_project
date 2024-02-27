namespace back_project.Data
{
    public interface IRepositoryGeneric<T> : IDisposable where T : class
    {
        Task Add(T entity); 
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void Update(T entity); 
        Task Delete(int id);
        Task Save(); 
    }
}
