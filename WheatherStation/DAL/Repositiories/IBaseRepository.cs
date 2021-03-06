using WheatherStation.DAL.Entities;

namespace WheatherStation.DAL.Repositiories
{
    public interface IBaseRepository<T> where T : IEntity
    {
        IQueryable<T> GetAllQueryable();
        Task<IEnumerable<T>> FindAll();
        Task<T> FindLastData();
        Task<bool> isExists(int id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Save();
    }
}
