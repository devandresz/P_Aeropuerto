var projectRoot = ResolveProjectRoot();

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = projectRoot,
    WebRootPath = Path.Combine(projectRoot, "wwwroot")
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AeropuertoWeb.Models.DatabaseManager>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();

static string ResolveProjectRoot()
{
    var current = Directory.GetCurrentDirectory();

    if (File.Exists(Path.Combine(current, "AeropuertoWeb.csproj")))
    {
        return current;
    }

    var nestedProject = Path.Combine(current, "AeropuertoWeb", "AeropuertoWeb");
    if (File.Exists(Path.Combine(nestedProject, "AeropuertoWeb.csproj")))
    {
        return nestedProject;
    }

    var directory = new DirectoryInfo(current);
    while (directory != null)
    {
        if (File.Exists(Path.Combine(directory.FullName, "AeropuertoWeb.csproj")))
        {
            return directory.FullName;
        }

        directory = directory.Parent;
    }

    return current;
}
