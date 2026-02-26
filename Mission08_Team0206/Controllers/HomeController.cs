using Microsoft.AspNetCore.Mvc;
using Mission08_Team0206.Models;
using Microsoft.EntityFrameworkCore; 

namespace Mission08_Team0206.Controllers;

public class HomeController : Controller
{
    private readonly ITaskRepository _repo;

    public HomeController(ITaskRepository temp)
    {
        _repo = temp;
    }

    // --- HOME PAGE (Now shows ONLY Completed Tasks) ---
    [HttpGet]
    public IActionResult Index()
    {
        // Fetch ONLY completed tasks to display on the Home page
        var completedTasks = _repo.TaskItems
            .Include(t => t.Category) 
            .Where(t => t.Completed == true)
            .ToList();

        return View(completedTasks);
    }

    // --- QUADRANTS MATRIX VIEW ---
    [HttpGet]
    public IActionResult Quad()
    {
        // Fetch uncompleted tasks and include the Category data for the view
        var uncompletedTasks = _repo.TaskItems
            .Include(t => t.Category) 
            .Where(t => t.Completed == false)
            .ToList();

        return View(uncompletedTasks);
    }

    // --- CREATE TASK (GET) ---
    [HttpGet]
    public IActionResult Create() 
    {
        ViewBag.Categories = _repo.Categories.OrderBy(c => c.CategoryName).ToList();
        return View("TaskForm", new TaskItem()); 
    }

    // --- EDIT TASK (GET) ---
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var taskToEdit = _repo.GetTaskById(id); 
        if (taskToEdit == null) return NotFound();

        ViewBag.Categories = _repo.Categories.OrderBy(c => c.CategoryName).ToList();
        
        return View("TaskForm", taskToEdit);
    }

    // --- SAVE TASK (POST) - Handles both Adding and Editing ---
    [HttpPost]
    public IActionResult SaveTask(TaskItem task)
    {
        if (ModelState.IsValid)
        {
            if (task.TaskItemId == 0) // A new task will have an ID of 0
            {
                _repo.AddTask(task);
            }
            else // If it has an ID, we are updating an existing task
            {
                _repo.UpdateTask(task);
            }
            
            _repo.SaveChanges(); 
            return RedirectToAction("Quad");
        }
        
        // If validation fails, reload categories and show the form again
        ViewBag.Categories = _repo.Categories.OrderBy(c => c.CategoryName).ToList();
        return View("TaskForm", task);
    }

    // --- INSTANT DELETE TASK (POST) - Bypasses missing view ---
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var taskToDelete = _repo.GetTaskById(id);
        if (taskToDelete != null)
        {
            _repo.DeleteTask(taskToDelete);
            _repo.SaveChanges();
        }
        return RedirectToAction("Quad");
    }

    // --- MARK COMPLETED (POST) ---
    [HttpPost]
    public IActionResult MarkCompleted(int id)
    {
        var task = _repo.GetTaskById(id);
        if (task != null)
        {
            task.Completed = true;
            _repo.UpdateTask(task);
            _repo.SaveChanges();
        }
        return RedirectToAction("Quad");
    }
}