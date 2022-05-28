using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TeamManageApp.Data;
using TeamManageApp.Models;
using TeamManageApp.Services.HashPasswordService;
using TeamManageApp.Services.IssueService;
using TeamManageApp.Services.TeamService;
using TeamManageApp.Services.UserService;
using TeamManageApp.ViewModels;

namespace TeamManageApp.Controllers
{
    [Authorize(Policy = "All")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IHashPasswordService _hashPasswordService;
        private readonly ITeamService _teamRepository;
        private readonly IIssueService _issueService;

        public HomeController(
            ILogger<HomeController> logger
            , IUserService userService
            , IHashPasswordService hashPasswordService
            , ITeamService teamRepository
            , IIssueService issueService
            )
        {
            _logger = logger;
            _userService = userService;
            _hashPasswordService = hashPasswordService;
            _teamRepository = teamRepository;
            _issueService = issueService;
        }

        public async Task<IActionResult> Index(int? id = 3, int? option = null)
        {
            var userLogin = HttpContext.User.Identity?.Name;
            var currentUser = await _userService.GetUserByLogin(userLogin);

            ViewBag.User = currentUser;
            ViewBag.State = id;

            if (id == 1)
            {
                //TODO:Add pagination
                ViewBag.UserEditModel = (await _userService.GetUsers(0, int.MaxValue))
                    .Select(u => new UserEditModel { Id = u.Id, Login = $"{u.FullName}" }).ToList();

                ViewBag.Teams = await _teamRepository.GetAllTeams(0, int.MaxValue);
            }

            if (id == 3)
            {
                var users = (await _userService.GetUsers(0, int.MaxValue))
                    .Select(u => new UserEditModel { Id = u.Id, Login = $"{u.FullName}" }).ToList();

                ViewBag.Reporters = users;
                ViewBag.Asignees = users;

                ViewBag.MyIssuesAsignees = (await _userService.GetUserByLogin(HttpContext.User.Identity.Name)).AsigneeIssues.Union((await _userService.GetUserByLogin(HttpContext.User.Identity.Name)).ReporterIssues).Distinct().ToList();
                ViewBag.LinkedIsuues = await _issueService.GetAllIssues(0, int.MaxValue);
            }

            if (id == 4)
            {
                //TODO:Add pagination
                ViewBag.Users = await _userService.GetUsers(0, int.MaxValue);
                ViewBag.Roles = new List<string>() { Constants.QA, Constants.Developer, Constants.Analytic, Constants.ProjectManager };
            }

            if (id == 5)
            {
                var users = (await _userService.GetUsers(0, int.MaxValue))
                   .Select(u => new UserEditModel { Id = u.Id, Login = $"{u.FullName}" }).ToList();

                ViewBag.Reporters = users;
                ViewBag.Asignees = users;

                ViewBag.PickedIssue = await _issueService.GetIssue((int)option);
                ViewBag.LinkedIsuues = await _issueService.GetAllIssues(0, int.MaxValue);
            }

            if (id == 6)
            {
                ViewBag.AllIssues = await _issueService.GetAllIssues(0, int.MaxValue);
            }

            return View();
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);

            return Redirect("/home/index/4");
        }

        public async Task<IActionResult> DeleteIssue(int id)
        {
            await _issueService.DeleteIssue(id);

            return Redirect("/home/index/3");
        }

        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamRepository.DeleteTeam(id);

            return Redirect("/home/index/1");
        }

        public ActionResult Teams()
        {
            return PartialView("_Teams");
        }

        public async Task<ActionResult> Profile()
        {
            return PartialView("_Profile");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(UserEditModel model)
        {
            try
            {
                var user = await _userService.GetUserById(model.Id);
                user.FullName = model.FullName;
                user.Login = model.Login;

                await _userService.UpdateUser(user);

                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };

                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            }
            catch (Exception ex)
            {
                //TODO: Make execption handler
            }

            return Redirect("/home/index/2");
        }

        public ActionResult MyIssues()
        {
            return PartialView("_MyIssues");
        }

        public ActionResult MyIssue()
        {
            return PartialView("_MyIssue");
        }

        public ActionResult Users()
        {
            return PartialView("_Users");
        }

        //Add user
        [HttpPost]
        public async Task<IActionResult> Index(string login, string password, string fullName, string role)
        {
            try
            {
                var userId = await _userService.AddUser(new Models.User() { FullName = fullName, Password = _hashPasswordService.HashPassword(password), Login = login, Role = role });
            }
            catch (Exception ex)
            {
                //TODO: Make exception handler
            }

            return Redirect("/home/index/4");
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssue(IssueModel issue)
        {
            try
            {
                var issueId = await _issueService.CreateIssue(new Issue
                {
                    Description = issue.Description,
                    AsigneeId = issue.AssigneeId,
                    Name = issue.Name,
                    Priority = issue.Priority,
                    ReporterId = issue.ReporterId,
                    Status = issue.Status,
                    Comments = issue.Comments,
                    TeamId = (int)(await _userService.GetUserByLogin(HttpContext.User.Identity.Name)).TeamId
                }, issue.LinkedIssuesIds?.ToList());
            }
            catch (Exception)
            { }

            return Redirect("/home/index/3");
        }

        [HttpPost]
        public async Task<IActionResult> EditIssue(IssueModel issue)
        {
            try
            {
                await _issueService.UpdateIssue(new Issue
                {
                    Id = issue.Id,
                    Description = issue.Description,
                    AsigneeId = issue.AssigneeId,
                    Name = issue.Name,
                    Priority = issue.Priority,
                    ReporterId = issue.ReporterId,
                    Status = issue.Status,
                    Comments = issue.Comments
                }, issue.LinkedIssuesIds?.ToList());
            }
            catch (Exception ex)
            { 
            
            }

            return Redirect($"/home/index/5/{issue.Id}");
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(TeamModel team)
        {
            try
            {
                var teamId = await _teamRepository.CreateTeam(new Team
                {
                    Name = team.Name,
                    Comments = team.Comments,
                    Description = team.Description,
                    EstimateFrom = team.EstimateFrom,
                    EstimateTo = team.EstimateTo,
                    Methodologies = team.Methodologies,
                    CreaterId = (await _userService.GetUserByLogin(HttpContext.User.Identity.Name)).Id
                });

                foreach (var userId in team.UsersIds)
                {
                    await _userService.AddUserToTeam(userId, teamId);
                }
            }
            catch (Exception)
            { }

            return Redirect("/home/index/1");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}