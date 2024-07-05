namespace aspLearning.Interfaces;

public interface IUnitOfWork
{
    IGenericRepository<T> Rep<T>() where T : class;
    int Complete();
}