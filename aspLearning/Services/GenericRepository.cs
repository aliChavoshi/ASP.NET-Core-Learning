using System.Linq.Expressions;
using aspLearning.Context;
using aspLearning.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Services;

public class GenericRepository<TEntity>(DbContext myContext) : IGenericRepository<TEntity> where TEntity : class
{
    public void Add(TEntity entity)
    {
        myContext.Add(entity);
    }

    public void Update(TEntity entity)
    {
        myContext.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        myContext.Remove(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        myContext.RemoveRange(entities);
    }

    public TEntity GetById(int id)
    {
        // id ==1
        //T == course
        //return myContext.Find<TEntity>(id)!;
        return myContext.Set<TEntity>().Find(id)!;
    }

    public List<TEntity> GetAll()
    {
        return myContext.Set<TEntity>().ToList();
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
    {
        return myContext.Set<TEntity>().Where(predicate).ToList();
    }

    public bool Any(Expression<Func<TEntity, bool>> predicate)
    {
        //first => 1000 , 1
        //single     => 2 === exc
        return myContext.Set<TEntity>().Any(predicate); //true , false
    }

    public bool SaveChanges()
    {
        return myContext.SaveChanges() > 0;
    }
}