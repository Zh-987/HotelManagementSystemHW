using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotelManagemnetSystemHW.Infrastructure
{
    public class ImageModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder _modelBinder = new ImageModelBinder();

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(Image) ? _modelBinder : null;
        }
    }
}
