using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace hw_1.Infrastructure
{
    public class ImageModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            ILoggerFactory loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
            IModelBinder binder = new ImageModelProvider(new SimpleTypeModelBinder(typeof(DateTime), loggerFactory));
            return context.Metadata.ModelType == typeof(DateTime) ? binder : null;
        }
    }
}
