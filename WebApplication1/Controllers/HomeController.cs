using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    readonly ITimeService _timeService;
    public HomeController(ILogger<HomeController> logger, ITimeService timeService)
    {
      _logger = logger;
      _timeService = timeService;
    }
    public string Index2() {
      return _timeService.Time;
    }
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public async Task GetUsers() {
      string content = @"
          <form method = 'post'>
          <label>User name: </label><br/>          
          <input name='username' /><br/>
          <label>Age: </label><br/>  
          <input name='age' type='number'/> 
          <input type='submit' value='Send'/> </form>"; 
    
      Response.ContentType = "text/html;charset=utf-8";
      await Response.WriteAsync(content);
    }
    
    [HttpPost]
    public string GetUsers(string username, int age) {
      return $"{username}:{age}";      
    }
    public IActionResult ContentResult() {
      return Content("Hello ITSTEP!");
    }

    public JsonResult JsonExample()
    {
      return Json("name");
    }

    public IActionResult JsonResultExample() {
      User user = new User(001, "qwerty");
      return Json(user);
    }

    public IActionResult RedirectExample() {
      return Redirect("~/home/ContentExample");
    }

    public IActionResult FileExample() {
      string file_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files/text.txt");
      //byte[] array = System.IO.File.ReadAllBytes(file_path);
      FileStream fileStream = new FileStream(file_path, FileMode.Open);
      string file_type = "text/plain";
      string file_name = "text.txt";
      //return PhysicalFile(file_path,file_type, file_name);
      return File(fileStream, file_type, file_name);
    }
    public IActionResult FileVirtualExample() {
      return File("files/text.txt","text/plain","hello.txt");
    }

  }
  public record class User(int UserID, string Username);
}