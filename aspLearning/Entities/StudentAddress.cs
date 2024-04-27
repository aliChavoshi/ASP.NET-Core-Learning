namespace aspLearning.Entities;

public class StudentAddress
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    public string Country { get; set; }

    //relation   == foreign key
    //one-to-one
    public int StudentId { get; set; }
    public Student Student { get; set; }
}