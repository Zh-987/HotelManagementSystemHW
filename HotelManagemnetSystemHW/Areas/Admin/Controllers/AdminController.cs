using HotelManagemnetSystemHW.Areas.User.Models;
using HotelManagemnetSystemHW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Diagnostics.Metrics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HotelManagemnetSystemHW.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        ApplicationContext db;
        public AdminController(ApplicationContext context)
        {
            db = context;
        }

        //[Route("{area}")]
        //public IActionResult Index()
        //{
        //    List<HotelManagemnetSystemHW.Models.User> users = db.users.ToList();
        //    return View(users);
        //}

        [Route("{area}")]
        public ActionResult Index(string? username, RoleEnum? role, string? country, UsersSortState sortOrder = UsersSortState.IdAsc, int page = 1)
        {
            int pageSize = 3;   // количество элементов на странице

            IQueryable<HotelManagemnetSystemHW.Models.User>? users = db.users;

            if (!string.IsNullOrEmpty(country))
            {
                users = users.Where(p => p.Country == country);
            } 
            if (!string.IsNullOrEmpty(username))
            {
                users = users.Where(p => p.Username!.Contains(username));
            }
            if (role != null)
            {
                users = users.Where(p => p.Role == role);
            }
            List<HotelManagemnetSystemHW.Models.User?> countries = db.users.GroupBy(u => u.Country).Select(u => u.FirstOrDefault()).ToList();

            // пагинация
            var count = users.Count();
            users = users.Skip((page - 1) * pageSize).Take(pageSize);

            UserListViewModel viewModel = new UserListViewModel
            {
                Users = users,
                Countries = new SelectList(countries, "Country", "Country", country),
                Username = username,
                Role = role,
                PageViewModel = new PageViewModel(count, page, pageSize),
            };

            ViewData["IdSort"] = sortOrder == UsersSortState.IdAsc ? UsersSortState.IdDesc : UsersSortState.IdAsc;
            ViewData["FullnameSort"] = sortOrder == UsersSortState.FullnameAsc ? UsersSortState.FullnameDesc : UsersSortState.FullnameAsc;
            ViewData["UsernameSort"] = sortOrder == UsersSortState.UsernameAsc ? UsersSortState.UsernameDesc : UsersSortState.UsernameAsc;
            ViewData["PasswordSort"] = sortOrder == UsersSortState.PasswordAsc ? UsersSortState.PasswordDesc : UsersSortState.PasswordAsc;
            ViewData["DateOfBirthSort"] = sortOrder == UsersSortState.DateOfBirthAsc ? UsersSortState.DateOfBirthDesc : UsersSortState.DateOfBirthAsc;
            ViewData["SexSort"] = sortOrder == UsersSortState.SexAsc ? UsersSortState.SexDesc : UsersSortState.SexAsc;
            ViewData["EmailSort"] = sortOrder == UsersSortState.EmailAsc ? UsersSortState.EmailDesc : UsersSortState.EmailAsc;
            ViewData["PhoneSort"] = sortOrder == UsersSortState.PhoneAsc ? UsersSortState.PhoneDesc : UsersSortState.PhoneAsc;
            ViewData["CountrySort"] = sortOrder == UsersSortState.CountryAsc ? UsersSortState.CountryDesc : UsersSortState.CountryAsc;
            ViewData["RoleSort"] = sortOrder == UsersSortState.RoleAsc ? UsersSortState.RoleDesc : UsersSortState.RoleAsc;

            viewModel.Users = sortOrder switch
            {
                //SortState.IdAsc => users.OrderByDescending(s => s.Id),
                UsersSortState.IdDesc => viewModel.Users.OrderByDescending(s => s.Id),

                UsersSortState.FullnameAsc => viewModel.Users.OrderBy(s => s.Fullname),
                UsersSortState.FullnameDesc => viewModel.Users.OrderByDescending(s => s.Fullname),

                UsersSortState.UsernameAsc => viewModel.Users.OrderBy(s => s.Username),
                UsersSortState.UsernameDesc => viewModel.Users.OrderByDescending(s => s.Username),

                UsersSortState.PasswordAsc => viewModel.Users.OrderBy(s => s.Password),
                UsersSortState.PasswordDesc => viewModel.Users.OrderByDescending(s => s.Password),

                UsersSortState.DateOfBirthAsc => viewModel.Users.OrderBy(s => s.DateOfBirth),
                UsersSortState.DateOfBirthDesc => viewModel.Users.OrderByDescending(s => s.DateOfBirth),

                UsersSortState.SexAsc => viewModel.Users.OrderBy(s => s.Sex),
                UsersSortState.SexDesc => viewModel.Users.OrderByDescending(s => s.Sex),

                UsersSortState.EmailAsc => viewModel.Users.OrderBy(s => s.Email),
                UsersSortState.EmailDesc => viewModel.Users.OrderByDescending(s => s.Email),

                UsersSortState.PhoneAsc => viewModel.Users.OrderBy(s => s.Phone),
                UsersSortState.PhoneDesc => viewModel.Users.OrderByDescending(s => s.Phone),

                UsersSortState.CountryAsc => viewModel.Users.OrderBy(s => s.Country),
                UsersSortState.CountryDesc => viewModel.Users.OrderByDescending(s => s.Country),

                UsersSortState.RoleAsc => viewModel.Users.OrderBy(s => s.Role),
                UsersSortState.RoleDesc => viewModel.Users.OrderByDescending(s => s.Role),

                _ => viewModel.Users.OrderBy(s => s.Id),
            };
            return View(viewModel);
        }

        public IActionResult HttpHeaders()
        {
            Dictionary<string, string> htmlHeaders = new Dictionary<string, string>();
            foreach (var header in Request.Headers)
            {
                htmlHeaders.Add(header.Key, header.Value);
            }
            return View(htmlHeaders);
        }
    }
}
