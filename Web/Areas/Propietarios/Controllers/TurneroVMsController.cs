using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Areas.Propietarios.Models;
using Web.Data;

namespace Web.Areas.Propietarios.Controllers
{
    [Area("Propietarios")]
    public class TurneroVMsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TurneroVMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Propietarios/TurneroVMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TurneroVM.ToListAsync());
        }

        // GET: Propietarios/TurneroVMs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turneroVM = await _context.TurneroVM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turneroVM == null)
            {
                return NotFound();
            }

            return View(turneroVM);
        }

        // GET: Propietarios/TurneroVMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Propietarios/TurneroVMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Concepto,Ubicacion")] TurneroVM turneroVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turneroVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turneroVM);
        }

        // GET: Propietarios/TurneroVMs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turneroVM = await _context.TurneroVM.FindAsync(id);
            if (turneroVM == null)
            {
                return NotFound();
            }
            return View(turneroVM);
        }

        // POST: Propietarios/TurneroVMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Concepto,Ubicacion")] TurneroVM turneroVM)
        {
            if (id != turneroVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turneroVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurneroVMExists(turneroVM.Id))
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
            return View(turneroVM);
        }

        // GET: Propietarios/TurneroVMs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turneroVM = await _context.TurneroVM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turneroVM == null)
            {
                return NotFound();
            }

            return View(turneroVM);
        }

        // POST: Propietarios/TurneroVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var turneroVM = await _context.TurneroVM.FindAsync(id);
            _context.TurneroVM.Remove(turneroVM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurneroVMExists(string id)
        {
            return _context.TurneroVM.Any(e => e.Id == id);
        }
    }
}
