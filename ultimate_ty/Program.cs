//Importa libreria de Autenticacion con Cookies
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Crea el servicio de Autenticacion con el esquema de cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        //ruta de login
        option.LoginPath = "/Acceso/Index";
        //tiempo n que expira la cookie en minutos
        option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
        //ruta en caso de Acceso denegado
        option.AccessDeniedPath = "/Home/Privacy";
    }

    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//Habilita Autenticacion y autorizacion
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Index}/{id?}");

app.Run();
