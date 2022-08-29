﻿using System;
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

        // GET: Task
        public async Task<IActionResult> Index()
        {
            var mainContext = _context.Tasks.Include(t => t.TaskCreater).Include(t => t.TaskWorker);
            return View(await mainContext.ToListAsync());
        }

        // GET: Task/Details/5
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

        // GET: Task/Create
        public IActionResult Create()
        {
            ViewData["TaskCreaterID"] = new SelectList(_context.Users, "UserID", "UserID");
            ViewData["TaskWorkerID"] = new SelectList(_context.Users, "UserID", "UserID");
            return View();
        }

        // POST: Task/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskID,Name,Description,CreatedDate,UpdatedDate,TaskStatus,TaskCreaterID,TaskWorkerID")] Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaskCreaterID"] = new SelectList(_context.Users, "UserID", "UserID", task.TaskCreaterID);
            ViewData["TaskWorkerID"] = new SelectList(_context.Users, "UserID", "UserID", task.TaskWorkerID);
            return View(task);
        }

        // GET: Task/Edit/5
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
            ViewData["TaskCreaterID"] = new SelectList(_context.Users, "UserID", "UserID", task.TaskCreaterID);
            ViewData["TaskWorkerID"] = new SelectList(_context.Users, "UserID", "UserID", task.TaskWorkerID);
            return View(task);
        }

        // POST: Task/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskID,Name,Description,CreatedDate,UpdatedDate,TaskStatus,TaskCreaterID,TaskWorkerID")] Task task)
        {
            if (id != task.TaskID)
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
            }
            ViewData["TaskCreaterID"] = new SelectList(_context.Users, "UserID", "UserID", task.TaskCreaterID);
            ViewData["TaskWorkerID"] = new SelectList(_context.Users, "UserID", "UserID", task.TaskWorkerID);
            return View(task);
        }

        // GET: Task/Delete/5
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

        // POST: Task/Delete/5
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