using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotelManagemnetSystemHW.Infrastructure
{
    public class HotelModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var idValues = bindingContext.ValueProvider.GetValue("Id");
            var nameValues = bindingContext.ValueProvider.GetValue("Name");
            var imageValues = bindingContext.ValueProvider.GetValue("Image");
            var descriptionValues = bindingContext.ValueProvider.GetValue("Description");
            var ratingValues = bindingContext.ValueProvider.GetValue("Rating");

            int.TryParse(idValues.FirstValue, out int id_);
            int id = id_;

            string? name = nameValues.FirstValue;
            string? image = imageValues.FirstValue;
            string? description = descriptionValues.FirstValue;

            int.TryParse(ratingValues.FirstValue, out int rating_);
            int rating = rating_;

            var hotel = new Hotel(id, name, image, description, rating, null);

            bindingContext.Result = ModelBindingResult.Success(hotel);
            return Task.CompletedTask;

        }
    }
}
