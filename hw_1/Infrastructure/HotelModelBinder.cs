using hw_1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace hw_1.Infrastructure
{
    public class HotelModelBinder : IModelBinder
    {
        private readonly IModelBinder fallbackBinder;
        public HotelModelBinder(IModelBinder fallbackBinder)
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
            var imageValues = bindingContext.ValueProvider.GetValue("Image");
            var descriptionValues = bindingContext.ValueProvider.GetValue("Description");
            var ratingValues = bindingContext.ValueProvider.GetValue("Rating");

 
            if (idValues == ValueProviderResult.None || nameValues == ValueProviderResult.None || imageValues == ValueProviderResult.None || descriptionValues == ValueProviderResult.None || ratingValues == ValueProviderResult.None)
                return fallbackBinder.BindModelAsync(bindingContext);

            
            int.TryParse(idValues.FirstValue, out int _id);
            int id = _id;

            string? name = nameValues.FirstValue;
            string? image = imageValues.FirstValue;
            string? description = descriptionValues.FirstValue;

            int.TryParse(ratingValues.FirstValue, out int _rating);
            int rating = _rating;

            var res = new Hotel(id, name, image, description, rating, new List<Room> {});

            bindingContext.Result = ModelBindingResult.Success(res);
            return Task.CompletedTask;
        }
    }
}
