using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotelManagemnetSystemHW.Infrastructure
{
    public class RoomsFeaturesModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder _modelBinder = new RoomsFeaturesModelBinder();

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(RoomsFeatures) ? _modelBinder : null;
        }
    }
}
