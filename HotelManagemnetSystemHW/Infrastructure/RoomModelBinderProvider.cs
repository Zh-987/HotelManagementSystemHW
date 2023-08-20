using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotelManagemnetSystemHW.Infrastructure
{
    public class RoomModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder _modelBinder = new RoomModelBinder();

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(Room) ? _modelBinder : null;
        }
    }
}
