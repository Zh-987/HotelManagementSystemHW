using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Xml.Linq;

namespace HotelManagemnetSystemHW.Infrastructure
{
    public class ReservationModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var idValues = bindingContext.ValueProvider.GetValue("Id");
            var checkInDateValues = bindingContext.ValueProvider.GetValue("CheckInDate");
            var checkInTimeValues = bindingContext.ValueProvider.GetValue("CheckInTime");
            var checkOutDateValues = bindingContext.ValueProvider.GetValue("CheckOutDate");
            var checkOutTimeValues = bindingContext.ValueProvider.GetValue("CheckOutTime");
            var eldersValue = bindingContext.ValueProvider.GetValue("Elders");
            var childrenValue = bindingContext.ValueProvider.GetValue("Children");
            var userIdValue = bindingContext.ValueProvider.GetValue("UserId");
            var roomIdValue = bindingContext.ValueProvider.GetValue("RoomId");

            int.TryParse(idValues.FirstValue, out int id_);
            int id = id_;

            string? checkInDate = checkInDateValues.FirstValue;
            string? checkInTime = checkInTimeValues.FirstValue;
            string? checkOutDate = checkOutDateValues.FirstValue;
            string? checkOutTime = checkOutTimeValues.FirstValue;

            int.TryParse(eldersValue.FirstValue, out int elders_);
            int elders = elders_;

            int.TryParse(childrenValue.FirstValue, out int childrenValue_);
            int children = childrenValue_;

            string? userId = userIdValue.FirstValue;

            int.TryParse(roomIdValue.FirstValue, out int roomId_);
            int roomId = roomId_;

            DateTime.TryParse(checkInDate, out var parsedCheckInDateValue);
            DateTime.TryParse(checkInTime, out var parsedCheckInTimeValue);
            DateTime.TryParse(checkOutDate, out var parsedCheckOutDateValue);
            DateTime.TryParse(checkOutTime, out var parsedCheckOutTimeValue);

            DateTime fullcheckInDateTime = new DateTime(
                parsedCheckInDateValue.Year,
                parsedCheckInDateValue.Month,
                parsedCheckInDateValue.Day,
                parsedCheckInTimeValue.Hour,
                parsedCheckInTimeValue.Minute,
                parsedCheckInTimeValue.Second);

            DateTime fullcheckOutDateTime = new DateTime(
                parsedCheckOutDateValue.Year,
                parsedCheckOutDateValue.Month,
                parsedCheckOutDateValue.Day,
                parsedCheckOutTimeValue.Hour,
                parsedCheckOutTimeValue.Minute,
                parsedCheckOutTimeValue.Second);

            var reservation = new Reservation(id, fullcheckInDateTime, fullcheckOutDateTime, elders, children, userId, roomId, null, null);

            bindingContext.Result = ModelBindingResult.Success(reservation);
            return Task.CompletedTask;

        }
    }
}
