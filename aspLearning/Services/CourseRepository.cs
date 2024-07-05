using System.Linq.Expressions;
using aspLearning.Context;
using aspLearning.Entities;
using aspLearning.Interfaces;

namespace aspLearning.Services;

public class CourseRepository(MyContext context) : GenericRepository<Course>(context), ICourseRepository
{
    public List<Course> GetTopSellingCourses(int count)
    {
        return context.Courses.OrderByDescending(x => x.FullPrice).Take(count).ToList();
    }
}