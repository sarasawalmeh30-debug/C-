
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tasksara.Models;


public class TasksController : Controller
{
    private readonly MyDbContext _context;

    public TasksController(MyDbContext context)
    {
        _context = context;
    }

    // GET: TASKS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Tasks.ToListAsync());
    }

    // GET: TASKS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var task = await _context.Tasks
            .FirstOrDefaultAsync(m => m.TaskId == id);
        if (task == null)
        {
            return NotFound();
        }

        return View(task);
    }

    // GET: TASKS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TASKS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("TaskId,TaskName,StartDate,EndDate,Employees")] tasksara.Models.Task task)
    {
            _context.Add(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        
        return View(task);
    }

    // GET: TASKS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }

    // POST: TASKS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("TaskId,TaskName,StartDate,EndDate,Employees")] tasksara.Models.Task task)
    {
        if (id != task.TaskId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(task);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(task.TaskId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(task);
    }

    // GET: TASKS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var task = await _context.Tasks
            .FirstOrDefaultAsync(m => m.TaskId == id);
        if (task == null)
        {
            return NotFound();
        }

        return View(task);
    }

    // POST: TASKS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TaskExists(int? id)
    {
        return _context.Tasks.Any(e => e.TaskId == id);
    }
}
