using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Entities;

public class Course
{
    [Key] public int Id { get; set; }

    public int AuthorId { get; set; }


    #region Relations

    public Author Author { get; set; }

    #endregion
}