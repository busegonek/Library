var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    name: "AboutUs",
    pattern: "AboutUs", // Eðer "Hakkimizda" olarak kullanmak istiyorsanýz burayý "Hakkimizda" olarak deðiþtirin
    defaults: new { controller = "Home", action = "AboutUs" });

app.MapControllerRoute(
    name: "Categories",
    pattern: "Categories",
    defaults: new { controller = "Home", action = "Categories" });

app.MapControllerRoute(
    name: "Contact",
    pattern: "Contact",
    defaults: new { controller = "Home", action = "Contact" });




app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
