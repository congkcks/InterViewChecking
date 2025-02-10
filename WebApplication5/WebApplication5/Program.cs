using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    app.Map("/ShowOptions", appOptions => {
        appOptions.Run(async (context) => {

            StringBuilder stb = new StringBuilder();
            IConfiguration configuration = appOptions.ApplicationServices.GetService<IConfiguration>();

            var testoptions = configuration.GetSection("TestOptions");  // Đọc một Section trả về IConfigurationSection
            var opt_key1 = testoptions["opt_key1"];                  // Đọc giá trị trong Section
            var k1 = testoptions.GetSection("opt_key2")["k1"]; // Đọc giá trị trong Section con
            var k2 = configuration["TestOptions:opt_key2:k2"]; // Đọc giá trị trong Section

            stb.Append($"   TestOptions.opt_key1:  {opt_key1}\n");
            stb.Append($"TestOptions.opt_key2.k1:  {k1}\n");
            stb.Append($"TestOptions.opt_key2.k2:  {k2}\n");

            await context.Response.WriteAsync(stb.ToString().HtmlTag("pre"));


        });
    });
}
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


