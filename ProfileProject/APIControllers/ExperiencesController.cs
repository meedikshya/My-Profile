using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ProfileProject.Data;
using ProfileProject.Models;
using ProfileProject.DTOs.ExperienceDTOs;

namespace ProfileProject.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        private readonly ProfileProjectContext _context;
        private readonly IMapper _mapper;

        public ExperiencesController(ProfileProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Experiences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExperienceReadDTOs>>> GetExperiences()
        {
            var experiences = await _context.Experience.ToListAsync();
            var experienceDTOs = _mapper.Map<IEnumerable<ExperienceReadDTOs>>(experiences);
            return Ok(experienceDTOs);
        }

        // GET: api/Experiences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExperienceReadDTOs>> GetExperience(int id)
        {
            var experience = await _context.Experience.FindAsync(id);

            if (experience == null)
            {
                return NotFound();
            }

            var experienceDTO = _mapper.Map<ExperienceReadDTOs>(experience);
            return Ok(experienceDTO);
        }

        // GET: api/Experiences/User/5
        [HttpGet("Users/{id}")]
        public async Task<ActionResult<IEnumerable<ExperienceReadDTOs>>> GetUserExperiences(int id)
        {
            var experiences = await _context.Experience
                                             .Where(e => e.UserId == id)
                                             .ToListAsync();

            if (!experiences.Any())
            {
                return NotFound();
            }

            var experienceDTOs = _mapper.Map<IEnumerable<ExperienceReadDTOs>>(experiences);
            return Ok(experienceDTOs);
        }

        // PUT: api/Experiences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperience(int id, ExperienceUpdateDTOs experienceUpdateDTO)
        {
            if (id != experienceUpdateDTO.ExperienceId)
            {
                return BadRequest();
            }

            var experience = _mapper.Map<Experience>(experienceUpdateDTO);
            _context.Entry(experience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceExists(id))
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

        // POST: api/Experiences
        [HttpPost]
        public async Task<ActionResult<ExperienceReadDTOs>> PostExperience(ExperienceCreateDTOs experienceCreateDTO)
        {
            var experience = _mapper.Map<Experience>(experienceCreateDTO);
            _context.Experience.Add(experience);
            await _context.SaveChangesAsync();

            var experienceReadDTO = _mapper.Map<ExperienceReadDTOs>(experience);
            return CreatedAtAction("GetExperience", new { id = experience.ExperienceId }, experienceReadDTO);
        }

        // DELETE: api/Experiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var experience = await _context.Experience.FindAsync(id);
            if (experience == null)
            {
                return NotFound();
            }

            _context.Experience.Remove(experience);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExperienceExists(int id)
        {
            return _context.Experience.Any(e => e.ExperienceId == id);
        }
    }
}
