using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ProfileProject.Data;
using ProfileProject.Models;
using ProfileProject.DTOs.EducationDTOs;

namespace ProfileProject.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly ProfileProjectContext _context;
        private readonly IMapper _mapper;

        public EducationsController(ProfileProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Educations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationReadDTOs>>> GetEducations()
        {
            var educations = await _context.Education.ToListAsync();
            var educationDTOs = _mapper.Map<IEnumerable<EducationReadDTOs>>(educations);
            return Ok(educationDTOs);
        }

        // GET: api/Educations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EducationReadDTOs>> GetEducation(int id)
        {
            var education = await _context.Education.FindAsync(id);

            if (education == null)
            {
                return NotFound();
            }

            var educationDTO = _mapper.Map<EducationReadDTOs>(education);
            return Ok(educationDTO);
        }

        // GET: api/Educations/User/5
        [HttpGet("Users/{id}")]
        public async Task<ActionResult<IEnumerable<EducationReadDTOs>>> GetUserEducations(int id)
        {
            var educations = await _context.Education.Where(e => e.UserId == id).ToListAsync();

            if (!educations.Any())
            {
                return NotFound();
            }

            var educationDTOs = _mapper.Map<IEnumerable<EducationReadDTOs>>(educations);
            return Ok(educationDTOs);
        }

        // PUT: api/Educations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducation(int id, EducationUpdateDTOs educationUpdateDTO)
        {
            if (id != educationUpdateDTO.EducationId)
            {
                return BadRequest();
            }

            var education = _mapper.Map<Education>(educationUpdateDTO);
            _context.Entry(education).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(id))
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

        // POST: api/Educations
        [HttpPost]
        public async Task<ActionResult<EducationReadDTOs>> PostEducation(EducationCreateDTOs educationCreateDTO)
        {
            var education = _mapper.Map<Education>(educationCreateDTO);
            _context.Education.Add(education);
            await _context.SaveChangesAsync();

            var educationReadDTO = _mapper.Map<EducationReadDTOs>(education);
            return CreatedAtAction("GetEducation", new { id = education.EducationId }, educationReadDTO);
        }

        // DELETE: api/Educations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var education = await _context.Education.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }

            _context.Education.Remove(education);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EducationExists(int id)
        {
            return _context.Education.Any(e => e.EducationId == id);
        }
    }
}
