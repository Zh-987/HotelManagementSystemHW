using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;

namespace HotelManagemnetSystemHW.Infrastructure
{
    public class RoomModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var idValues = bindingContext.ValueProvider.GetValue("Id");
            var nameValues = bindingContext.ValueProvider.GetValue("Name");
            var descriptionValues = bindingContext.ValueProvider.GetValue("Description");
            var personCountValues = bindingContext.ValueProvider.GetValue("PersonCount");
            var squareValues = bindingContext.ValueProvider.GetValue("Square");
            var costValues = bindingContext.ValueProvider.GetValue("Cost");
            var HotelIdValues = bindingContext.ValueProvider.GetValue("HotelId");


            int.TryParse(idValues.FirstValue, out int id_);
            int id = id_;

            string? name = nameValues.FirstValue;
            string? description = descriptionValues.FirstValue;

            int.TryParse(personCountValues.FirstValue, out int pC_);
            int personCount = pC_;

            int.TryParse(squareValues.FirstValue, out int square_);
            int square = square_;

            double.TryParse(costValues.FirstValue, out double cost_);
            double cost = cost_;

            int.TryParse(HotelIdValues.FirstValue, out int hotelId_);
            int hotelId = hotelId_;

            var room = new Room(id, name, description, personCount, square, cost, null, hotelId, null, null, null);

            bindingContext.Result = ModelBindingResult.Success(room);
            return Task.CompletedTask;
        }
    }
}
