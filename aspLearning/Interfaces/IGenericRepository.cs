using aspLearning.Entities;
using System.Linq.Expressions;

namespace aspLearning.Interfaces;

//T == Course , Author , ...
public interface IGenericRepository<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    T GetById(int id);
    List<T> GetAll();
    List<T> GetAll(Expression<Func<T, bool>> predicate);
}