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
    public class PersonalSkillsController : Controller
    {
        private readonly ProfileProjectContext _context;

        public PersonalSkillsController(ProfileProjectContext context)
        {
            _context = context;
        }

        // GET: PersonalSkills
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalSkill.ToListAsync());
        }

        // GET: PersonalSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalSkill = await _context.PersonalSkill
                .FirstOrDefaultAsync(m => m.PersonalSkillId == id);
            if (personalSkill == null)
            {
                return NotFound();
            }

            return View(personalSkill);
        }

        // GET: PersonalSkills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalSkillId,PersonalSkillType,PersonalSkillItems,UserId")] PersonalSkill personalSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalSkill);
        }

        // GET: PersonalSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalSkill = await _context.PersonalSkill.FindAsync(id);
            if (personalSkill == null)
            {
                return NotFound();
            }
            return View(personalSkill);
        }

        // POST: PersonalSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalSkillId,PersonalSkillType,PersonalSkillItems,UserId")] PersonalSkill personalSkill)
        {
            if (id != personalSkill.PersonalSkillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalSkillExists(personalSkill.PersonalSkillId))
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
            return View(personalSkill);
        }

        // GET: PersonalSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalSkill = await _context.PersonalSkill
                .FirstOrDefaultAsync(m => m.PersonalSkillId == id);
            if (personalSkill == null)
            {
                return NotFound();
            }

            return View(personalSkill);
        }

        // POST: PersonalSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalSkill = await _context.PersonalSkill.FindAsync(id);
            if (personalSkill != null)
            {
                _context.PersonalSkill.Remove(personalSkill);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalSkillExists(int id)
        {
            return _context.PersonalSkill.Any(e => e.PersonalSkillId == id);
        }
    }
}
