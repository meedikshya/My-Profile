using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileProject.Data;
using ProfileProject.Models;
using ProfileProject.DTOs.PersonalSkillDTOs;

namespace ProfileProject.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalSkillsController : ControllerBase
    {
        private readonly ProfileProjectContext _context;
        private readonly IMapper _mapper;

        public PersonalSkillsController(ProfileProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PersonalSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalSkillReadDTOs>>> GetPersonalSkills()
        {
            var personalSkills = await _context.PersonalSkill.ToListAsync();
            var personalSkillDTOs = _mapper.Map<IEnumerable<PersonalSkillReadDTOs>>(personalSkills);
            return Ok(personalSkillDTOs);
        }

        // GET: api/PersonalSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalSkillReadDTOs>> GetPersonalSkill(int id)
        {
            var personalSkill = await _context.PersonalSkill.FindAsync(id);

            if (personalSkill == null)
            {
                return NotFound();
            }

            var personalSkillDTO = _mapper.Map<PersonalSkillReadDTOs>(personalSkill);
            return Ok(personalSkillDTO);
        }

        // GET: api/PersonalSkills/User/5
        [HttpGet("Users/{id}")]
        public async Task<ActionResult<IEnumerable<PersonalSkillReadDTOs>>> GetUserPersonalSkills(int id)
        {
            var personalSkills = await _context.PersonalSkill
                                               .Where(p => p.UserId == id)
                                               .ToListAsync();

            if (!personalSkills.Any())
            {
                return NotFound();
            }

            var personalSkillDTOs = _mapper.Map<IEnumerable<PersonalSkillReadDTOs>>(personalSkills);
            return Ok(personalSkillDTOs);
        }

        // PUT: api/PersonalSkills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalSkill(int id, PersonalSkillUpdateDTOs personalSkillUpdateDTO)
        {
            if (id != personalSkillUpdateDTO.PersonalSkillId)
            {
                return BadRequest();
            }

            var personalSkill = _mapper.Map<PersonalSkill>(personalSkillUpdateDTO);
            _context.Entry(personalSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalSkillExists(id))
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

        // POST: api/PersonalSkills
        [HttpPost]
        public async Task<ActionResult<PersonalSkillReadDTOs>> PostPersonalSkill(PersonalSkillCreateDTOs personalSkillCreateDTO)
        {
            var personalSkill = _mapper.Map<PersonalSkill>(personalSkillCreateDTO);
            _context.PersonalSkill.Add(personalSkill);
            await _context.SaveChangesAsync();

            var personalSkillReadDTO = _mapper.Map<PersonalSkillReadDTOs>(personalSkill);
            return CreatedAtAction("GetPersonalSkill", new { id = personalSkill.PersonalSkillId }, personalSkillReadDTO);
        }

        // DELETE: api/PersonalSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalSkill(int id)
        {
            var personalSkill = await _context.PersonalSkill.FindAsync(id);
            if (personalSkill == null)
            {
                return NotFound();
            }

            _context.PersonalSkill.Remove(personalSkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalSkillExists(int id)
        {
            return _context.PersonalSkill.Any(e => e.PersonalSkillId == id);
        }
    }
}
