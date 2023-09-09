using HotelManagemnetSystemHW.Infrastructure;
using HotelManagemnetSystemHW.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

// 1.1 Добавить сервис AddControllersWithViews ()
builder.Services.AddControllersWithViews(
        opts => { 
            opts.ModelBinderProviders.Insert(0, new HotelModelBinderProvider());
            opts.ModelBinderProviders.Insert(1, new ImageModelBinderProvider());
            opts.ModelBinderProviders.Insert(2, new ReservationModelBinderProvider());
            opts.ModelBinderProviders.Insert(3, new RoomModelBinderProvider());
            opts.ModelBinderProviders.Insert(4, new RoomsFeaturesModelBinderProvider());
        });

// 1.4 Добавить возможость использование рейзер движка
builder.Services.AddRazorPages();

var app = builder.Build();

// 1.2 Добавить Страницу ошибку по дефолту
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 1.4 Добавить https переходы
app.UseHttpsRedirection();

// 1.4 Добавить использования статических файлов
app.UseStaticFiles();

// 1.4 Добавить использования маршрутизации
app.UseRouting();

// 1.4 Добавить использование аутентификации и авторизации
app.UseAuthentication();
app.UseAuthorization();

// 1.3 Настроить MapControllerRoute()
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 1.4 Добавить возможость использование рейзер движка
app.MapRazorPages();

app.Run();