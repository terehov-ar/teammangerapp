using Microsoft.AspNetCore.Authentication.Cookies;
using TeamManageApp.Data;
using TeamManageApp.Repositories.IssueListRepository;
using TeamManageApp.Repositories.IssueRepository;
using TeamManageApp.Repositories.TeamRepository;
using TeamManageApp.Repositories.UserRepository;
using TeamManageApp.Services.HashPasswordService;
using TeamManageApp.Services.IssueService;
using TeamManageApp.Services.TeamService;
using TeamManageApp.Services.UserService;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
        options.LoginPath = "/Account/Login";
    });
builder.Services.AddAuthorization(opt => 
{
    opt.AddPolicy("All", pol => 
    {
        pol.RequireRole(Constants.QA, Constants.Developer, Constants.Analytic, Constants.ProjectManager);
    }); 
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddNpgsql<Context>(connectionString);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITeamRepository, TeamRepository>();
builder.Services.AddTransient<IIssueRepository, IssueRepository>();
builder.Services.AddTransient<IIssueListRepository, IssueListRepository>();

builder.Services.AddTransient<IHashPasswordService, HashPasswordService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITeamService, TeamService>();
builder.Services.AddTransient<IIssueService, IssueService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{option?}");

app.Run();
