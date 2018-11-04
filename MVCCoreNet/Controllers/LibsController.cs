using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCoreNet.Models;
using MVCCoreNet.ViewModels;

namespace MVCCoreNet.Controllers
{
    public class LibsController : Controller
    {
        private readonly MVCContext _context;

        public LibsController(MVCContext context)
        {
            _context = context;
        }

        // GET: Libs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lib.Include(nameof(Categorie)).ToListAsync());
        }

        // GET: Libs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lib = await _context.Lib.Include(nameof(Categorie))
                .FirstOrDefaultAsync(m => m.IdLib == id);
            if (lib == null)
            {
                return NotFound();
            }

            return View(lib);
        }

        // GET: Libs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLib,Nom,Description,IdCategorie")] Lib lib)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lib);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lib);
        }

        // GET: Libs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Lib lib = null;
            var vm = new LibViewModel();
            var listeCat = await _context.Categorie.ToListAsync();
            if(listeCat == null || listeCat.Count <= 0)
            {
                return NotFound("la liste des catégories est vide");
            }
            vm.SetModel(listeCat.OrderBy(x=>x.Nom).ToList());
            if (id == 0)
            {
                lib = new Lib();
                vm.CategorieSelected = listeCat[0].IdCategorie.ToString();
            }
            else
            {
                lib = await _context.Lib.FindAsync(id);
                var cat = await _context.Categorie.FindAsync(lib.IdCategorie);
                vm.CategorieSelected = cat.IdCategorie.ToString();
            }

            vm.Lib = lib;

            return View(vm);
        }

        // POST: Libs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LibViewModel model)
        {
            model.SetModel(await _context.Categorie.ToListAsync());
            model.Lib.IdCategorie = Convert.ToInt32(model.CategorieSelected);
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.Lib.IdLib != 0)
                    {
                        _context.Update(model.Lib);
                    }
                    else
                    {
                        _context.Lib.Add(model.Lib);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibExists(model.Lib.IdLib))
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
            return View(model);
        }

        // GET: Libs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lib = await _context.Lib.Include(nameof(Categorie))
                .FirstOrDefaultAsync(m => m.IdLib == id);
            if (lib == null)
            {
                return NotFound();
            }

            return View(lib);
        }

        // POST: Libs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lib = await _context.Lib.FindAsync(id);
            _context.Lib.Remove(lib);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibExists(int id)
        {
            return _context.Lib.Any(e => e.IdLib == id);
        }
    }
}
