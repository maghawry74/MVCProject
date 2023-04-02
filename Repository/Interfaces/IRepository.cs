using System.Linq.Expressions;

namespace Kotabko.Repository.Interfaces;

public interface IRepository<T> where T : class
{
    public IEnumerable<T> GetAll();
    public T? Find(Expression<Func<T, bool>> filter);
    public T Add(T entity);
    public bool Update(T entity);
    public bool Delete(Expression<Func<T, bool>> filter);
}
