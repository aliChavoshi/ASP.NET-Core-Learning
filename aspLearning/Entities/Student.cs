namespace aspLearning.Entities;

//principal
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    //relation
    public StudentAddress StudentAddress { get; set; }
}