using aspLearning.Context;
using aspLearning.Interfaces;

namespace aspLearning.Services;

public class UnitOfWork(MyContext context) : IUnitOfWork
{
    public ICourseRepository Courses { get; } = new CourseRepository(context);
    public IAuthorRepository Authors { get; } = new AuthorRepository(context);

    public int Complete()
    {
        return context.SaveChanges();
    }
}