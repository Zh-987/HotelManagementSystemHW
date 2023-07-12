var builder = WebApplication.CreateBuilder(args);

// 1.1 �������� ������ AddControllersWithViews ()
builder.Services.AddControllersWithViews();

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