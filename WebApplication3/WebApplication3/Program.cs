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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "studentList",
        pattern: "Admin/Student/List",
        defaults: new { controller = "Student", action = "Index" });

    endpoints.MapControllerRoute(
        name: "studentAdd",
        pattern: "Admin/Student/Add",
        defaults: new { controller = "Student", action = "Create" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Student}/{action=Index}/{id?}");
});

app.Run();
