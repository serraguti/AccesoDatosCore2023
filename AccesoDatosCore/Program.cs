using AccesoDatosCore.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//RECUPERAMOS LA CADENA DE CONEXION DE appsettings.json
string cadenaConexion = 
    builder.Configuration.GetConnectionString("hospitallocal");
//VAMOS A ENVIAR DIRECTAMENTE EL REPOSITORIO
//DEBEMOS CREAR MANUALMENTE EL REPOSITORIO CON LA CADENA Y ENVIARLO
RepositoryEmpleados repoEmp = new RepositoryEmpleados(cadenaConexion);
//INDICAMOS AL PROGRAMA EL REPOSITORIO A UTILIZAR
builder.Services.AddTransient<RepositoryEmpleados>(z => repoEmp);

RepositoryPlantilla repoPlantilla = new RepositoryPlantilla(cadenaConexion);
builder.Services.AddTransient<RepositoryPlantilla>(z => repoPlantilla);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
