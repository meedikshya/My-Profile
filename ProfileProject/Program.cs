using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProfileProject.Data;
using ProfileProject.Profiles;
using ProfileProject.Repository.GenericRepository;

var builder = WebApplication.CreateBuilder(args);

// Configure the DbContext
builder.Services.AddDbContext<ProfileProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProfileProjectContext")
        ?? throw new InvalidOperationException("Connection string 'ProfileProjectContext' not found.")));

// Configure AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IGenericRepositories, GenericRepositories>();

// Register AutoMapper and add the profile //resumeprofile is profils's name
builder.Services.AddAutoMapper(typeof(ResumeProfile));

// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policyBuilder => policyBuilder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin());
});

// Add services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Use CORS policy
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Index}/{id?}");

app.Run();
