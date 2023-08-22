using hw_1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace hw_1.Infrastructure
{
    public class RoomModelBinder : IModelBinder
    {
        private readonly IModelBinder fallbackBinder;
        public RoomModelBinder(IModelBinder fallbackBinder)
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
            var descriptionValues = bindingContext.ValueProvider.GetValue("Description");
            var personCountValues = bindingContext.ValueProvider.GetValue("PersonCount");
            var squareValues = bindingContext.ValueProvider.GetValue("Square");
            var costValues = bindingContext.ValueProvider.GetValue("Cost");
            var HotelIdValues = bindingContext.ValueProvider.GetValue("HotelId");


            if (idValues == ValueProviderResult.None || nameValues == ValueProviderResult.None
                || descriptionValues == ValueProviderResult.None || personCountValues == ValueProviderResult.None
                || squareValues == ValueProviderResult.None || costValues == ValueProviderResult.None
                || HotelIdValues == ValueProviderResult.None)
                return fallbackBinder.BindModelAsync(bindingContext);


            int.TryParse(idValues.FirstValue, out int _id);
            int id = _id;

            string? name = nameValues.FirstValue;
            string? description = descriptionValues.FirstValue;

            int.TryParse(personCountValues.FirstValue, out int _personCount);
            int personCount = _personCount;

            int.TryParse(squareValues.FirstValue, out int _square);
            int square = _square;

            double.TryParse(costValues.FirstValue, out double _cost);
            double cost = _cost;

            int.TryParse(HotelIdValues.FirstValue, out int _hotelId);
            int hotelId = _hotelId;

            var res = new Room(id, name, description, personCount, square, cost, new List<RoomsFeature> { }, hotelId, null, new List<Image> { }, new List<Reservation> { });

            bindingContext.Result = ModelBindingResult.Success(res);
            return Task.CompletedTask;
        }
    }
}
