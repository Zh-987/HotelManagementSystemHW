using HotelManagemnetSystemHW.Infrastructure;
using HotelManagemnetSystemHW.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

// 1.1 �������� ������ AddControllersWithViews ()
builder.Services.AddControllersWithViews(
        opts => { 
            opts.ModelBinderProviders.Insert(0, new HotelModelBinderProvider());
            opts.ModelBinderProviders.Insert(1, new ImageModelBinderProvider());
            opts.ModelBinderProviders.Insert(2, new ReservationModelBinderProvider());
            opts.ModelBinderProviders.Insert(3, new RoomModelBinderProvider());
            opts.ModelBinderProviders.Insert(4, new RoomsFeaturesModelBinderProvider());
        });

// 1.4 �������� ���������� ������������� ������ ������
builder.Services.AddRazorPages();

var app = builder.Build();

// 1.2 �������� �������� ������ �� �������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 1.4 �������� https ��������
app.UseHttpsRedirection();

// 1.4 �������� ������������� ����������� ������
app.UseStaticFiles();

// 1.4 �������� ������������� �������������
app.UseRouting();

// 1.4 �������� ������������� �������������� � �����������
app.UseAuthentication();
app.UseAuthorization();

// 1.3 ��������� MapControllerRoute()
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 1.4 �������� ���������� ������������� ������ ������
app.MapRazorPages();

app.Run();