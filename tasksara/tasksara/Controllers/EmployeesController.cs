
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tasksara.Models;

public class EmployeesController : Controller
{
    private readonly MyDbContext _context;

    public EmployeesController(MyDbContext context)
    {
        _context = context;
    }

    // GET: EMPLOYEES
    public async Task<IActionResult> Index()
    {
        var employees = await _context.Employees
            .Include(e => e.Manager)
            .Include( e => e.Tasks)
            .ToListAsync();

        return View(employees);
    }

    // GET: EMPLOYEES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _context.Employees
            .FirstOrDefaultAsync(m => m.EmployeeId == id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // GET: EMPLOYEES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: EMPLOYEES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EmployeeId,NameEmployee,EmailEmployee,PasswordEmployee,ManagerId,Manager,Tasks")] Employee employee)
    {
        //if (ModelState.IsValid)
        //{
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        //}
        return View(employee);
    }

    // GET: EMPLOYEES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    // POST: EMPLOYEES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("EmployeeId,NameEmployee,EmailEmployee,PasswordEmployee,ManagerId,Manager,Tasks")] Employee employee)
    {
        if (id != employee.EmployeeId)
        {
            return NotFound();
        }

        try
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmployeeExists(employee.EmployeeId))
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

    // GET: EMPLOYEES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _context.Employees
            .FirstOrDefaultAsync(m => m.EmployeeId == id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // POST: EMPLOYEES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EmployeeExists(int? id)
    {
        return _context.Employees.Any(e => e.EmployeeId == id);
    }


   

}
