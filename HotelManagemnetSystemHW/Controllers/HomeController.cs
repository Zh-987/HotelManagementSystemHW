using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Diagnostics;

namespace HotelManagemnetSystemHW.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        //public HomeController(ApplicationContext context)
        //{
        //    db = context;
        //}
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateHotel() => View();

        [HttpPost]
        public string CreateHotel(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                return $"{hotel.Name} - {hotel.Description} - {hotel.Image} - {hotel.Rating}";
            }
            return ValidateForm(ModelState);
        }

        [HttpGet]
        public IActionResult CreateImage() => View();

        [HttpPost]
        public string CreateImage(Image image)
        {
            if (ModelState.IsValid)
            {
                return $"{image.Name} - {image.IsMain} - {image.RoomId}";
            }
            return ValidateForm(ModelState);
        }

        [HttpGet]
        public IActionResult CreateReservation() => View();

        [HttpPost]
        public string CreateReservation(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                return $"{reservation.CheckIn} - {reservation.CheckOut} - {reservation.Elders} - {reservation.Children} - {reservation.UserId} - {reservation.RoomId}";
            }
            return ValidateForm(ModelState);
        }

        [HttpGet]
        public IActionResult CreateRoom() => View();

        [HttpPost]
        public string CreateRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                return $@"{room.Name} 
                        - {room.Description} 
                        - {room.PersonCount} 
                        - {room.Square} 
                        - {room.Cost} 
                        - {room.HotelId}";
            }
            return ValidateForm(ModelState);
        }

        [HttpGet]
        public IActionResult CreateRoomsFeatures() => View();

        [HttpPost]
        public string CreateRoomsFeatures(RoomsFeatures roomsFeatures)
        {
            if (ModelState.IsValid)
            {
                return $@"{roomsFeatures.FeatureId} 
                        - {roomsFeatures.RoomId}";
            }
            return ValidateForm(ModelState);
        }

        [HttpGet]
        public IActionResult CreateUser() => View();

        [HttpPost]
        public string CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                return $@"{user.Fullname} 
                        - {user.Username} 
                        - {user.Password} 
                        - {user.DateOfBirth} 
                        - {user.Sex} 
                        - {user.Email}
                        - {user.Phone}
                        - {user.Country}";
            }
            return ValidateForm(ModelState);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public string ValidateForm(ModelStateDictionary ModelState)
        {
            string errorMessages = "";
            // проходим по всем элементам в ModelState
            foreach (var item in ModelState)
            {
                // если для определенного элемента имеются ошибки
                if (item.Value.ValidationState == ModelValidationState.Invalid)
                {
                    errorMessages = $"{errorMessages}\nОшибки для свойства {item.Key}:\n";
                    // пробегаемся по всем ошибкам
                    foreach (var error in item.Value.Errors)
                    {
                        errorMessages = $"{errorMessages}{error.ErrorMessage}\n";
                    }
                }
            }
            return errorMessages;
        }
    }
}
