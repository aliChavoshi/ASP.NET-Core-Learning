﻿namespace aspLearning.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }


    //relations
    public ICollection<BookCategory> BookCategories { get; set; }
}