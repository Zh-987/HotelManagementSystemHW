using hw_1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace hw_1.Infrastructure
{
    public class ReservationModelBinder : IModelBinder
    {
        private readonly IModelBinder fallbackBinder;
        public ReservationModelBinder(IModelBinder fallbackBinder)
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
            var checkInDateValues = bindingContext.ValueProvider.GetValue("CheckInDate");
            var checkInTimeValues = bindingContext.ValueProvider.GetValue("CheckInTime");
            var checkOutDateValues = bindingContext.ValueProvider.GetValue("CheckOutDate");
            var checkOutTimeValues = bindingContext.ValueProvider.GetValue("CheckOutTime");
            var eldersValue = bindingContext.ValueProvider.GetValue("Elders");
            var childrenValue = bindingContext.ValueProvider.GetValue("Children");
            var userIdValue = bindingContext.ValueProvider.GetValue("UserId");
            var roomIdValue = bindingContext.ValueProvider.GetValue("RoomId");

            if (idValues == ValueProviderResult.None
                || checkInDateValues == ValueProviderResult.None
                || checkInTimeValues == ValueProviderResult.None 
                || checkOutDateValues == ValueProviderResult.None
                || checkOutTimeValues == ValueProviderResult.None
                || eldersValue == ValueProviderResult.None
                || childrenValue == ValueProviderResult.None
                || userIdValue == ValueProviderResult.None
                || roomIdValue == ValueProviderResult.None)
                return fallbackBinder.BindModelAsync(bindingContext);


            int.TryParse(idValues.FirstValue, out int _id);
            int id = _id;

            int.TryParse(eldersValue.FirstValue, out int _elders);
            int elders = _elders;

            int.TryParse(childrenValue.FirstValue, out int _childrenValue);
            int children = _childrenValue;

            string? userId = userIdValue.FirstValue;

            int.TryParse(roomIdValue.FirstValue, out int _roomId);
            int roomId = _roomId;

            DateTime.TryParse(checkInDateValues.FirstValue, out DateTime checkInDateValue);
            DateTime.TryParse(checkInTimeValues.FirstValue, out DateTime checkInTimeValue);
            DateTime.TryParse(checkOutDateValues.FirstValue, out DateTime checkOutDateValue);
            DateTime.TryParse(checkOutTimeValues.FirstValue, out DateTime checkOutTimeValue);

            DateTime fullcheckInDateTime = new DateTime(
                checkInDateValue.Year,
                checkInDateValue.Month,
                checkInDateValue.Day,
                checkInTimeValue.Hour,
                checkInTimeValue.Minute,
                checkInTimeValue.Second);

            DateTime fullcheckOutDateTime = new DateTime(
                checkOutDateValue.Year,
                checkOutDateValue.Month,
                checkOutDateValue.Day,
                checkOutTimeValue.Hour,
                checkOutTimeValue.Minute,
                checkOutTimeValue.Second);

            var res = new Reservation(id, fullcheckInDateTime, fullcheckOutDateTime, elders, children, userId, roomId, null, null);

            bindingContext.Result = ModelBindingResult.Success(res);
            return Task.CompletedTask;
        }
    }
}
