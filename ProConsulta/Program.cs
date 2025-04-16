using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MudBlazor.Services;
using ProConsulta.Components;
using ProConsulta.Components.Account;
using ProConsulta.Data;
using ProConsulta.Models;
using ProConsulta.Repositories;
using ProConsulta.Repositories.Doctors;
using ProConsulta.Repositories.Patients;
using ProConsulta.Repositories.Schedulings;
using ProConsulta.Repositories.Specialitys;
using ProConsulta.Components.Account.Shared;



var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddScoped<IPatientRepository, PatientRepository>(); // Primeiro a interface e DEPOIS a classe concreta
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<ISpecialitysRepository, SpecialityRepository>(); // Primeiro a interface e DEPOIS a classe concreta
builder.Services.AddScoped<ISchedulingsRepository, SchedulingsRepository>();


builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DataBase")
    ?? throw new InvalidOperationException("Connection string 'DataBase' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
           .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddIdentity<Attendant, IdentityRole>()
builder.Services.AddIdentityCore<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager<SignInManager<ApplicationUser>>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await SeedIdentityData.SeedUserAsync(userManager, roleManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
