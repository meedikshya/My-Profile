using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileProject.Data;
using ProfileProject.Models;
using ProfileProject.DTOs.TechnicalSkillDTOs;

namespace ProfileProject.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalSkillsController : ControllerBase
    {
        private readonly ProfileProjectContext _context;
        private readonly IMapper _mapper;

        public TechnicalSkillsController(ProfileProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TechnicalSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechnicalSkillReadDTOs>>> GetTechnicalSkills()
        {
            var technicalSkills = await _context.TechnicalSkill.ToListAsync();
            var technicalSkillDTOs = _mapper.Map<IEnumerable<TechnicalSkillReadDTOs>>(technicalSkills);
            return Ok(technicalSkillDTOs);
        }

        // GET: api/TechnicalSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TechnicalSkillReadDTOs>> GetTechnicalSkill(int id)
        {
            var technicalSkill = await _context.TechnicalSkill.FindAsync(id);

            if (technicalSkill == null)
            {
                return NotFound();
            }

            var technicalSkillDTO = _mapper.Map<TechnicalSkillReadDTOs>(technicalSkill);
            return Ok(technicalSkillDTO);
        }

        // GET: api/TechnicalSkills/User/5
        [HttpGet("Users/{id}")]
        public async Task<ActionResult<List<TechnicalSkillReadDTOs>>> GetUserTechnicalSkills(int id)
        {
            var technicalSkills = await _context.TechnicalSkill
                .Where(p => p.UserId == id)
                .ToListAsync();

            if (technicalSkills == null || !technicalSkills.Any())
            {
                return NotFound();
            }

            var technicalSkillDTOs = _mapper.Map<List<TechnicalSkillReadDTOs>>(technicalSkills);
            return Ok(technicalSkillDTOs);
        }

        // PUT: api/TechnicalSkills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnicalSkill(int id, TechnicalSkillUpdateDTOs technicalSkillUpdateDTO)
        {
            if (id != technicalSkillUpdateDTO.TechnicalSkillId)
            {
                return BadRequest();
            }

            var technicalSkill = _mapper.Map<TechnicalSkill>(technicalSkillUpdateDTO);
            _context.Entry(technicalSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnicalSkillExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TechnicalSkills
        [HttpPost]
        public async Task<ActionResult<TechnicalSkillReadDTOs>> PostTechnicalSkill(TechnicalSkillCreateDTOs technicalSkillCreateDTO)
        {
            var technicalSkill = _mapper.Map<TechnicalSkill>(technicalSkillCreateDTO);
            _context.TechnicalSkill.Add(technicalSkill);
            await _context.SaveChangesAsync();

            var technicalSkillDTO = _mapper.Map<TechnicalSkillReadDTOs>(technicalSkill);
            return CreatedAtAction("GetTechnicalSkill", new { id = technicalSkill.TechnicalSkillId }, technicalSkillDTO);
        }

        // DELETE: api/TechnicalSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnicalSkill(int id)
        {
            var technicalSkill = await _context.TechnicalSkill.FindAsync(id);
            if (technicalSkill == null)
            {
                return NotFound();
            }

            _context.TechnicalSkill.Remove(technicalSkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TechnicalSkillExists(int id)
        {
            return _context.TechnicalSkill.Any(e => e.TechnicalSkillId == id);
        }
    }
}
