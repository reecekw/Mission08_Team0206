using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0206.Models;
using System.Diagnostics;

namespace Mission08_Team0206.Controllers
{
    public class HomeController : Controller
    {
        // Declare _context here
        private readonly TaskContext _context;

        // Constructor injects TaskContext
        public HomeController(TaskContext context)
        {
            _context = context;
        }

        // Home page
        public IActionResult Index()
        {
            return View();
        }

        // Quadrants page
        public IActionResult Quad()
        {
            // Load incomplete tasks and include Category
            var tasks = _context.TaskItems
                .Include(t => t.Category)
                .Where(t => !t.Completed)
                .ToList();

            // Return your Quad.cshtml view
            return View("Quad", tasks);
        }

        // GET: /Home/Create – Display an empty form to add a new task
        public IActionResult Create()
        {
            // Pass categories list for the dropdown
            ViewBag.Categories = _context.Categories.ToList();

            // Return the TaskForm view with a blank TaskItem (TaskItemId will be 0)
            return View("TaskForm", new TaskItem());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var task = _context.TaskItems.Find(id);
            if (task != null)
            {
                _context.TaskItems.Remove(task);
                _context.SaveChanges();
            }

            // Redirect back to the Quad page after deletion
            return RedirectToAction("Quad");
        }

        // GET: /Home/Edit/5
        public IActionResult Edit(int id)
        {
            var task = _context.TaskItems
                .Include(t => t.Category)
                .FirstOrDefault(t => t.TaskItemId == id);

            if (task == null)
                return NotFound();

            // Pass categories for dropdown
            ViewBag.Categories = _context.Categories.ToList();

            // Return the form view (can be called TaskForm.cshtml)
            return View("TaskForm", task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveTask(TaskItem task)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View("TaskForm", task);
            }

            if (task.TaskItemId == 0)
            {
                // New task (Add) — your teammate will use this part
                _context.TaskItems.Add(task);
            }
            else
            {
                // Existing task (Edit)
                _context.TaskItems.Update(task);
            }

            _context.SaveChanges();
            return RedirectToAction("Quad");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}