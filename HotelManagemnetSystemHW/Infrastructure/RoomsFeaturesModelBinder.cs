using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

namespace HotelManagemnetSystemHW.Infrastructure
{
    public class RoomsFeaturesBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var idValues = bindingContext.ValueProvider.GetValue("Id");
            var featureIdValues = bindingContext.ValueProvider.GetValue("FeatureId");
            var roomIdValues = bindingContext.ValueProvider.GetValue("RoomId");

            int.TryParse(idValues.FirstValue, out int id_);
            int id = id_;

            int.TryParse(roomIdValues.FirstValue, out int roomId_);
            int roomId = roomId_;

            int.TryParse(featureIdValues.FirstValue, out int featureId_);
            int featureId = featureId_;

            var roomsFeatures = new RoomsFeatures(id, roomId, featureId, null);

            bindingContext.Result = ModelBindingResult.Success(roomsFeatures);
            return Task.CompletedTask;
        }
    }
}
