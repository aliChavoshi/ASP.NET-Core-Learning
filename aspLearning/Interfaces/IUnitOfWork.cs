namespace aspLearning.Interfaces;

public interface IUnitOfWork
{
    ICourseRepository Courses { get; }
    IAuthorRepository Authors { get; }
    int Complete();
}