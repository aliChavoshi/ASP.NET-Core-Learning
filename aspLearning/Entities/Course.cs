using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Entities;

public class Course
{
    [Key] public int Id { get; set; }

    public string Title { get; set; }

    public int AuthorId { get; set; }

    public int Level { get; set; }

    #region Relations

    public virtual Author Author { get; set; }

    //private List<Tags> _tags = null;
    public virtual List<Tags> Tags { get; set; }

    #endregion
}