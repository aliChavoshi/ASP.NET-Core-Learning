using Microsoft.EntityFrameworkCore;

namespace aspLearning.Interfaces;

public interface IUnitOfWork
{
    IGenericRepository<T> Rep<T>() where T : class;
    int Complete();
    DbContext Context { get; }
}