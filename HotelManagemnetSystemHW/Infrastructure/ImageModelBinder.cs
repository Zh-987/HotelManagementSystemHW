using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;

namespace HotelManagemnetSystemHW.Infrastructure
{
    public class ImageModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var idValues = bindingContext.ValueProvider.GetValue("Id");
            var nameValues = bindingContext.ValueProvider.GetValue("Name");
            var isMainValues = bindingContext.ValueProvider.GetValue("IsMain");
            var roomIdCountValues = bindingContext.ValueProvider.GetValue("RoomIdCount");

            int.TryParse(idValues.FirstValue, out int id_);
            int id = id_;

            string? name = nameValues.FirstValue;

            bool.TryParse(isMainValues.FirstValue, out bool isMain_);
            bool isMain = isMain_;

            int.TryParse(roomIdCountValues.FirstValue, out int roomIdCount_);
            int roomIdCount = roomIdCount_;
            var image = new Image(id, name, isMain, roomIdCount, null);

            bindingContext.Result = ModelBindingResult.Success(image);
            return Task.CompletedTask;
        }
    }
}
