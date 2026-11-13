
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tasksara.Models;

public class ManagersController : Controller
{
    private readonly MyDbContext _context;

    public ManagersController(MyDbContext context)
    {
        _context = context;
    }

    // GET: MANAGERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Managers.ToListAsync());
    }

    // GET: MANAGERS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var manager = await _context.Managers
            .FirstOrDefaultAsync(m => m.ManagerId == id);
        if (manager == null)
        {
            return NotFound();
        }

        return View(manager);
    }

    // GET: MANAGERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MANAGERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ManagerId,NameManager,EmailManager,PasswordManager,Employees")] Manager manager)
    {
        
            _context.Add(manager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        
        return View(manager);
    }

    // GET: MANAGERS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var manager = await _context.Managers.FindAsync(id);
        if (manager == null)
        {
            return NotFound();
        }
        return View(manager);
    }

    // POST: MANAGERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("ManagerId,NameManager,EmailManager,PasswordManager,Employees")] Manager manager)
    {
        if (id != manager.ManagerId)
        {
            return NotFound();
        }

        try
        {
            _context.Update(manager);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ManagerExists(manager.ManagerId))
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

    // GET: MANAGERS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var manager = await _context.Managers
            .FirstOrDefaultAsync(m => m.ManagerId == id);
        if (manager == null)
        {
            return NotFound();
        }

        return View(manager);
    }

    // POST: MANAGERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var manager = await _context.Managers.FindAsync(id);
        if (manager != null)
        {
            _context.Managers.Remove(manager);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ManagerExists(int? id)
    {
        return _context.Managers.Any(e => e.ManagerId == id);
    }

    [HttpGet]
    public async Task<IActionResult> AssignTask()
    {
        ViewBag.Employees = await _context.Employees.ToListAsync();
        ViewBag.Tasks = await _context.Tasks.ToListAsync();

        var employees = await _context.Employees
            .Include(e => e.Tasks)
            .ToListAsync();

        return View(employees);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AssignTask(int employeeId, int taskId)
    {
        var employee = await _context.Employees
            .Include(e => e.Tasks)
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

        var task = await _context.Tasks.FindAsync(taskId);

        if (employee == null || task == null)
        {
            return NotFound();
        }

        if (!employee.Tasks.Any(t => t.TaskId == taskId))
        {
            employee.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(AssignTask));
    }

}
