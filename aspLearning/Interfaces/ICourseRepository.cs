using aspLearning.Entities;

namespace aspLearning.Interfaces;

public interface ICourseRepository
{
    int Add(Course course);
    Course Update(Course course);
    void Delete(int id);
    Course FindById(int id);
}