using System.Linq.Expressions;
using aspLearning.Context;
using aspLearning.Entities;
using aspLearning.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Services;

public class CourseRepository(MyContext context) : GenericRepository<Course>(context), ICourseRepository
{
    public List<Course> GetTopSellingCourses(int count)
    {
        return context.Courses.OrderByDescending(x => x.FullPrice).Take(count).ToList();
    }

    public async Task<List<Course>> GetAllAsyncCourses(string filter)
    {
        var result = context.Courses.Include(x => x.Author)
            .AsQueryable();
        if (!string.IsNullOrEmpty(filter))
        {
            result = result.Where(c => c.Title.Contains(filter));
        }

        return await result.ToListAsync();
    }
}