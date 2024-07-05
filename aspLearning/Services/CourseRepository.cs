using System.Linq.Expressions;
using aspLearning.Context;
using aspLearning.Entities;
using aspLearning.Interfaces;

namespace aspLearning.Services;

public class CourseRepository(MyContext myContext) : ICourseRepository
{
    //SOLID
    //Interceptor
    public void Add(Course course)
    {
        myContext.Add(course);
    }

    public void Update(Course course)
    {
        myContext.Update(course);
    }

    public void Delete(Course course)
    {
        myContext.Remove(course);
    }

    public void DeleteRange(IEnumerable<Course> courses)
    {
        myContext.RemoveRange(courses);
    }

    public Course GetById(int id)
    {
        return myContext!.Courses!.Find(id)!;
    }

    public List<Course> GetAll()
    {
        //Func == delegate
        //Expression<Func<Course,Bool>>
        return myContext.Courses.ToList();
    }

    public List<Course> GetAll(Expression<Func<Course, bool>> predicate)
    {
        //IQ ==> List
        return myContext.Courses.Where(predicate).ToList();
    }

    public List<Course> GetTopSellingCourses(int count)
    {
        //count == take
        throw new NotImplementedException();
    }
}