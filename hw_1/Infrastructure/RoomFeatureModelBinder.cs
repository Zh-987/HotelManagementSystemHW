using hw_1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace hw_1.Infrastructure
{
    public class RoomFeatureModelBinder : IModelBinder
    {
        private readonly IModelBinder fallbackBinder;
        public RoomFeatureModelBinder(IModelBinder fallbackBinder)
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
            var featureIdValues = bindingContext.ValueProvider.GetValue("FeatureId");
            var roomIdValues = bindingContext.ValueProvider.GetValue("RoomId");


            if (idValues == ValueProviderResult.None || featureIdValues == ValueProviderResult.None 
                || roomIdValues == ValueProviderResult.None
               )
                return fallbackBinder.BindModelAsync(bindingContext);




            int.TryParse(idValues.FirstValue, out int _id);
            int id = _id;

            int.TryParse(roomIdValues.FirstValue, out int _roomId);
            int roomId = _roomId;

            int.TryParse(featureIdValues.FirstValue, out int _featureId);
            int featureId = _featureId;

            var roomsFeature = new RoomsFeature(id, roomId, null);

            bindingContext.Result = ModelBindingResult.Success(roomsFeature);
            return Task.CompletedTask;
        }
    }
}
