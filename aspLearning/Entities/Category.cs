namespace aspLearning.Entities;

public class Category
{
    public int Id { get; set; }
    public string CategoryName { get; set; }

    //relations
    public virtual ICollection<BookCategory> BookCategories { get; set; }
}