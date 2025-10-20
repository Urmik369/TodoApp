using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;


namespace TodoApp.Controllers
{
public class AccountController : Controller
{
private readonly ApplicationDbContext _context;
public AccountController(ApplicationDbContext context) { _context = context; }


public IActionResult Login() => View();
public IActionResult Register() => View();


[HttpPost]
public IActionResult Register(string username, string password)
{
if (_context.Users.Any(u => u.Username == username))
{
ViewBag.Error = "Username already exists.";
return View();
}
var user = new User
{
Username = username,
PasswordHash = PasswordHelper.HashPassword(password)
};
_context.Users.Add(user);
_context.SaveChanges();
return RedirectToAction("Login");
}


[HttpPost]
public async Task<IActionResult> Login(string username, string password)
{
var hashed = PasswordHelper.HashPassword(password);
var user = _context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hashed);
if (user == null)
{
ViewBag.Error = "Invalid login.";
return View();
}
var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), new Claim(ClaimTypes.Name, user.Username) };
var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
HttpContext.Session.SetString("UserId", user.Id.ToString());
return RedirectToAction("Index", "Tasks");
}


public async Task<IActionResult> Logout()
{
await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
return RedirectToAction("Login");
}
}
}