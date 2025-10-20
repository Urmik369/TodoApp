using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using System.Security.Claims;


namespace TodoApp.Controllers
{
[Authorize]
public class TasksController : Controller
{
private readonly ApplicationDbContext _context;
public TasksController(ApplicationDbContext context) { _context = context; }


public IActionResult Index()
{
	var idValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
	if (!int.TryParse(idValue, out var userId))
	{
		// If user id claim is missing or invalid, redirect to login
		return RedirectToAction("Login", "Account");
	}

	var tasks = _context.TodoItems.Where(t => t.UserId == userId).ToList();
	return View(tasks);
}


public IActionResult Create() => View();


[HttpPost]
public IActionResult Create(TodoItem item)
{
	var idValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
	if (!int.TryParse(idValue, out var userId))
	{
		return RedirectToAction("Login", "Account");
	}

	item.UserId = userId;
	_context.TodoItems.Add(item);
	_context.SaveChanges();
	return RedirectToAction("Index");
}


public IActionResult Edit(int id)
{
	var idValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
	if (!int.TryParse(idValue, out var userId))
	{
		return RedirectToAction("Login", "Account");
	}

	var item = _context.TodoItems.Find(id);
	if (item == null || item.UserId != userId)
	{
		return NotFound();
	}

	return View(item);
}


[HttpPost]
public IActionResult Edit(TodoItem item)
{
	var idValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
	if (!int.TryParse(idValue, out var userId))
	{
		return RedirectToAction("Login", "Account");
	}

	var existing = _context.TodoItems.Find(item.Id);
	if (existing == null || existing.UserId != userId)
	{
		return NotFound();
	}

	// Update only editable fields. Do NOT change UserId to avoid FK constraint issues.
	existing.Title = item.Title;
	existing.Description = item.Description;
	existing.DueDate = item.DueDate;
	existing.IsCompleted = item.IsCompleted;

	_context.SaveChanges();
	return RedirectToAction("Index");
}


public IActionResult Delete(int id)
{
	var idValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
	if (!int.TryParse(idValue, out var userId))
	{
		return RedirectToAction("Login", "Account");
	}

	var task = _context.TodoItems.Find(id);
	if (task == null || task.UserId != userId)
	{
		return NotFound();
	}

	return View(task);
}


[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public IActionResult DeleteConfirmed(int id)
{
	var idValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
	if (!int.TryParse(idValue, out var userId))
	{
		return RedirectToAction("Login", "Account");
	}

	var task = _context.TodoItems.Find(id);
	if (task == null || task.UserId != userId)
	{
		return NotFound();
	}

	_context.TodoItems.Remove(task);
	_context.SaveChanges();
	return RedirectToAction("Index");
}
}
}