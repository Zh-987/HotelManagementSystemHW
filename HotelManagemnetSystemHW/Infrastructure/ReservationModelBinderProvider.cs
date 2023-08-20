using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotelManagemnetSystemHW.Infrastructure
{
    public class ReservationModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder _modelBinder = new ReservationModelBinder();

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(Reservation) ? _modelBinder : null;
        }
    }
}
