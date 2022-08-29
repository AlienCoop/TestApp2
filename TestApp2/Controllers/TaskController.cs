using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestApp2.DAL;
using TestApp2.Models;
using Task = TestApp2.Models.Task;

namespace TestApp2.Controllers
{
    public class TaskController : Controller
    {
        private readonly MainContext _context;

        public TaskController(MainContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var mainContext = _context.Tasks.Include(t => t.TaskCreater).Include(t => t.TaskWorker);
            return View(await mainContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.TaskCreater)
                .Include(t => t.TaskWorker)
                .FirstOrDefaultAsync(m => m.TaskID == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }


        public IActionResult Create()
        {
            ViewData["TaskCreaterID"] = new SelectList(_context.Users, "UserID", "Name");
            ViewData["TaskWorkerID"] = new SelectList(_context.Users, "UserID", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskID,Name,Description,CreatedDate,UpdatedDate,TaskStatus,TaskCreaterID,TaskWorkerID")] Task task)
        {
            _context.Add(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            ViewData["TaskCreaterID"] = new SelectList(_context.Users, "UserID", "Name", task.TaskCreaterID);
            ViewData["TaskWorkerID"] = new SelectList(_context.Users, "UserID", "Name", task.TaskWorkerID);
            return View(task);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            ViewData["TaskCreaterID"] = new SelectList(_context.Users, "UserID", "Name", task.TaskCreaterID);
            ViewData["TaskWorkerID"] = new SelectList(_context.Users, "UserID", "Name", task.TaskWorkerID);
            return View(task);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskID,Name,Description,CreatedDate,UpdatedDate,TaskStatus,TaskCreaterID,TaskWorkerID")] Task task)
        {
            if (id != task.TaskID)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.TaskID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            
            return RedirectToAction(nameof(Index));
       
            ViewData["TaskWorkerID"] = new SelectList(_context.Users, "UserID", "Name", task.TaskWorkerID);
            return View(task);
        }


        public async Task<IActionResult> ChangeTaskStatus(int? id)
        {
            if (id == null || _context.Tasks == null)
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeTaskStatus(int id, [Bind("TaskID,TaskStatus")] Task task)
        {
            var temp = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskID == task.TaskID);
            temp.TaskStatus = task.TaskStatus;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    

        public async Task<IActionResult> ChangeTaskCreater(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            ViewData["TaskCreaterID"] = new SelectList(_context.Users, "UserID", "Name", task.TaskCreaterID);

            return View(task);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeTaskCreater([Bind("TaskID,TaskCreaterID")] Task task)
        {
            var temp = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskID == task.TaskID);
            temp.TaskCreaterID = task.TaskCreaterID;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.TaskCreater)
                .Include(t => t.TaskWorker)
                .FirstOrDefaultAsync(m => m.TaskID == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tasks == null)
            {
                return Problem("Entity set 'MainContext.Tasks'  is null.");
            }
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
          return (_context.Tasks?.Any(e => e.TaskID == id)).GetValueOrDefault();
        }
    }
}
