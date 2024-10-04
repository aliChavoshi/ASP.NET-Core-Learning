using aspLearning.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace aspLearning.Binders;

public class CourseBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType == typeof(Course))
        {
            return new BinderTypeModelBinder(typeof(CourseModelBinder));
        }

        return null;
    }
}