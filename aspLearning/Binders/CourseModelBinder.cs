using aspLearning.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace aspLearning.Binders;

public class CourseModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var course = new Course();
        if (bindingContext.ValueProvider.GetValue("Title").Length > 0)
        {
            course.Title = bindingContext.ValueProvider.GetValue("Title").FirstValue!;
        }
        if (bindingContext.ValueProvider.GetValue("Id").Length > 0)
        {
            course.Id = int.Parse(bindingContext.ValueProvider.GetValue("Id").FirstValue!);
        }
        if (bindingContext.ValueProvider.GetValue("Level").Length > 0)
        {
            course.AuthorId = int.Parse(bindingContext.ValueProvider.GetValue("AuthorId").FirstValue!);
        }
        if (bindingContext.ValueProvider.GetValue("AuthorId").Length > 0)
        {
            course.Level = int.Parse(bindingContext.ValueProvider.GetValue("Level").FirstValue!);
        }
        if (bindingContext.ValueProvider.GetValue("FullPrice").Length > 0)
        {
            course.FullPrice = float.Parse(bindingContext.ValueProvider.GetValue("FullPrice").FirstValue!);
        }

        bindingContext.Result = ModelBindingResult.Success(course);
        return Task.CompletedTask;
    }
}