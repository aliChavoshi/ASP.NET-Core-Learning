using System.Linq.Expressions;
using aspLearning.Entities;

namespace aspLearning.Interfaces;

//mix generic
public interface ICourseRepository : IGenericRepository<Course>    
{
    //Custom
    List<Course> GetTopSellingCourses(int count);
    Task<List<Course>> GetAllAsyncCourses(string filter);
}