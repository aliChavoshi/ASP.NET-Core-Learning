using System.Linq.Expressions;
using aspLearning.Entities;

namespace aspLearning.Interfaces;

//mix generic
public interface ICourseRepository
{
    void Add(Course course);
    void Update(Course course);
    void Delete(Course course);
    void DeleteRange(IEnumerable<Course> courses);
    Course GetById(int id);
    List<Course> GetAll();
    List<Course> GetAll(Expression<Func<Course, bool>> predicate);

    List<Course> GetTopSellingCourses(int count);
}