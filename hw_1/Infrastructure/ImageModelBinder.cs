using hw_1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace hw_1.Infrastructure
{
    public class ImageModelProvider : IModelBinder
    {
        private readonly IModelBinder fallbackBinder;
        public ImageModelProvider(IModelBinder fallbackBinder)
        {
            this.fallbackBinder = fallbackBinder;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {

            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var idValues = bindingContext.ValueProvider.GetValue("Id");
            var nameValues = bindingContext.ValueProvider.GetValue("Name");
            var isMainValues = bindingContext.ValueProvider.GetValue("IsMain");
            var roomIdCountValues = bindingContext.ValueProvider.GetValue("RoomId");


            if (idValues == ValueProviderResult.None || nameValues == ValueProviderResult.None || isMainValues == ValueProviderResult.None || roomIdCountValues == ValueProviderResult.None)
                return fallbackBinder.BindModelAsync(bindingContext);


            int.TryParse(idValues.FirstValue, out int id_);
            int id = id_;

            string? name = nameValues.FirstValue;

            bool.TryParse(isMainValues.FirstValue, out bool _isMain);
            bool isMain = _isMain;

            int.TryParse(roomIdCountValues.FirstValue, out int _roomId);
            int roomId = _roomId;
            var res = new Image(id, name, isMain, roomId, null);

            bindingContext.Result = ModelBindingResult.Success(res);
            return Task.CompletedTask;
        }
    }
}
