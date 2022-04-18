#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class PlanoController : Controller
    {
        private readonly AppDbContext _context;

        public PlanoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PlanoModels
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Planos.Include(p => p.Parceiro);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PlanoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoModel = await _context.Planos
                .Include(p => p.Parceiro)
                .FirstOrDefaultAsync(m => m.PlanoId == id);
            if (planoModel == null)
            {
                return NotFound();
            }

            return View(planoModel);
        }

        // GET: PlanoModels/Create
        public IActionResult Create()
        {
            ViewData["ParceiroId"] = new SelectList(_context.Parceiros, "ParceiroId", "ParceiroCep");
            return View();
        }

        // POST: PlanoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanoId,NomePlano,TermoDeUso,PrecoPlano,DescontoPlano,tipoPlano,ParceiroId")] PlanoModel planoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParceiroId"] = new SelectList(_context.Parceiros, "ParceiroId", "ParceiroCep", planoModel.ParceiroId);
            return View(planoModel);
        }

        // GET: PlanoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoModel = await _context.Planos.FindAsync(id);
            if (planoModel == null)
            {
                return NotFound();
            }
            ViewData["ParceiroId"] = new SelectList(_context.Parceiros, "ParceiroId", "ParceiroCep", planoModel.ParceiroId);
            return View(planoModel);
        }

        // POST: PlanoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlanoId,NomePlano,TermoDeUso,PrecoPlano,DescontoPlano,tipoPlano,ParceiroId")] PlanoModel planoModel)
        {
            if (id != planoModel.PlanoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoModelExists(planoModel.PlanoId))
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
            ViewData["ParceiroId"] = new SelectList(_context.Parceiros, "ParceiroId", "ParceiroCep", planoModel.ParceiroId);
            return View(planoModel);
        }

        // GET: PlanoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoModel = await _context.Planos
                .Include(p => p.Parceiro)
                .FirstOrDefaultAsync(m => m.PlanoId == id);
            if (planoModel == null)
            {
                return NotFound();
            }

            return View(planoModel);
        }

        // POST: PlanoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planoModel = await _context.Planos.FindAsync(id);
            _context.Planos.Remove(planoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoModelExists(int id)
        {
            return _context.Planos.Any(e => e.PlanoId == id);
        }
    }
}
