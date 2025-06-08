using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfileProject.Data;
using ProfileProject.Models;

namespace ProfileProject.Controllers
{
    public class TechnicalSkillsController : Controller
    {
        private readonly ProfileProjectContext _context;

        public TechnicalSkillsController(ProfileProjectContext context)
        {
            _context = context;
        }

        // GET: TechnicalSkills
        public async Task<IActionResult> Index()
        {
            return View(await _context.TechnicalSkill.ToListAsync());
        }

        // GET: TechnicalSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalSkill = await _context.TechnicalSkill
                .FirstOrDefaultAsync(m => m.TechnicalSkillId == id);
            if (technicalSkill == null)
            {
                return NotFound();
            }

            return View(technicalSkill);
        }

        // GET: TechnicalSkills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TechnicalSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TechnicalSkillId,TechnicalSkillType,TechnicalSkillItem,UserId")] TechnicalSkill technicalSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(technicalSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(technicalSkill);
        }

        // GET: TechnicalSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalSkill = await _context.TechnicalSkill.FindAsync(id);
            if (technicalSkill == null)
            {
                return NotFound();
            }
            return View(technicalSkill);
        }

        // POST: TechnicalSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TechnicalSkillId,TechnicalSkillType,TechnicalSkillItem,UserId")] TechnicalSkill technicalSkill)
        {
            if (id != technicalSkill.TechnicalSkillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(technicalSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechnicalSkillExists(technicalSkill.TechnicalSkillId))
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
            return View(technicalSkill);
        }

        // GET: TechnicalSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalSkill = await _context.TechnicalSkill
                .FirstOrDefaultAsync(m => m.TechnicalSkillId == id);
            if (technicalSkill == null)
            {
                return NotFound();
            }

            return View(technicalSkill);
        }

        // POST: TechnicalSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var technicalSkill = await _context.TechnicalSkill.FindAsync(id);
            if (technicalSkill != null)
            {
                _context.TechnicalSkill.Remove(technicalSkill);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechnicalSkillExists(int id)
        {
            return _context.TechnicalSkill.Any(e => e.TechnicalSkillId == id);
        }
    }
}
