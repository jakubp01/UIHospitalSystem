using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Inz.Areas.Identity.Data;
using System;
using Inz.Queries;
using Inz.CommandsQueries.Commands;
using Inz.CommandsQueries.Queries;
using Inz.Controllers.CreateControllers;
using Inz.CommandsQueries.Queries.ChartsRelatedQueries;
using Inz;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("appDbContextConnection") ?? throw new InvalidOperationException("Connection string 'appDbContextConnection' not found.");

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, UserClaimsPrincipalFactory<AppUser, IdentityRole>>();

builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(GetAllDoctorsQuery.Handler).Assembly,
        typeof(GetAllPatientsQuery.Handler).Assembly,
        typeof(GetClosestVisitsByDoctorId.Handler).Assembly,
        typeof(GetMyVisitsQuery.Handler).Assembly,
        typeof(GetSingleVisitQuery.Handler).Assembly,
        typeof(GetAllVisitsByPatientIdQuery.Handler).Assembly,
        typeof(GetDoctorVisitHistoryQuery.Handler).Assembly,
        typeof(GetVisitsToApproveQuery.Handler).Assembly,
        typeof(CreateVisitCommand.Handler).Assembly,
        typeof(CreatePatientCommand.Handler).Assembly,
        typeof(AddInterviewCommand.Handler).Assembly,
        typeof(GetSingleDoctorQuery.Handler).Assembly,
        typeof(GetBasicVisitsChartData.Handler).Assembly,
        typeof(GetVisitGrowByMonthsDataQuery.Handler).Assembly,
        typeof(RemovePatientProfileCommand.Handler).Assembly,
        typeof(RemoveDoctorCommand.Handler).Assembly


        );
});
builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var context = services.GetRequiredService<AppDbContext>();
    var passwordHasher = new PasswordHasher<AppUser>();
    if (context.AspNetUsers.IsNullOrEmpty())
    {
        var superAdmin = new AppUser
        {
            FirstName = "Admin",
            LastName = "Admin",
            HomeAddress = "Adminowa 2b",
            PhoneNumber = "123456789",
            IdentityNumber = "1234567890",
            RoleId = 2,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            Email = "admin@gmail.com",
            UserName = "admin@gmail.com"
        };

        var Doctor = new AppUser
        {
            FirstName = "User",
            LastName = "User",
            HomeAddress = "Userowa 2b",
            PhoneNumber = "123456789",
            IdentityNumber = "1234567890",
            RoleId = 1,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            Email = "user@gmail.com",
            UserName = "user@gmail.com"
        };
        await userManager.CreateAsync(Doctor, "User12!");
        await userManager.CreateAsync(superAdmin, "Admin12!");
        await context.SaveChangesAsync();
    }
}

    if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
     pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
