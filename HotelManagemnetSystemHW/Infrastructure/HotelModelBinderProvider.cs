using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotelManagemnetSystemHW.Infrastructure
{
    public class HotelModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder _modelBinder = new HotelModelBinder();

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(Hotel) ? _modelBinder : null;
        }
    }
}
