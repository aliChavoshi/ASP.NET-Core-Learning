using aspLearning.Interfaces;

namespace aspLearning.Services;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
}