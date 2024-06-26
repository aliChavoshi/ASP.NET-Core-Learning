using aspLearning.Context;
using aspLearning.Entities;
using aspLearning.Interfaces;

namespace aspLearning.Services;

public class CourseRepository(MyContext myContext) : ICourseRepository
{
    public int Add(Course course)
    {
        myContext.Add(course);
        myContext.SaveChanges();
        return course.Id;
    }

    public Course Update(Course course)
    {
        myContext.Update(course);
        myContext.SaveChanges();
        return course;
    }

    public void Delete(int id)
    {
        var entity = FindById(id);
        myContext.Remove(entity);
        myContext.SaveChanges();
    }

    public Course FindById(int id)
    {
        return myContext.Courses.Find(id);
    }
}