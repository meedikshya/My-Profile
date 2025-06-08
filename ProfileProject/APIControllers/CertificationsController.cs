using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ProfileProject.Data;
using ProfileProject.Models;
using ProfileProject.DTOs.CertificationDTOs;

namespace ProfileProject.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificationsController : ControllerBase
    {
        private readonly ProfileProjectContext _context;
        private readonly IMapper _mapper;

        public CertificationsController(ProfileProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Certifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificationReadDTOs>>> GetCertifications()
        {
            var certifications = await _context.Certification.ToListAsync();
            var certificationDTOs = _mapper.Map<IEnumerable<CertificationReadDTOs>>(certifications);
            return Ok(certificationDTOs);
        }

        // GET: api/Certifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificationReadDTOs>> GetCertification(int id)
        {
            var certification = await _context.Certification.FindAsync(id);

            if (certification == null)
            {
                return NotFound();
            }

            var certificationDTO = _mapper.Map<CertificationReadDTOs>(certification);
            return Ok(certificationDTO);
        }

        // GET: api/Certifications/User/5
        [HttpGet("Users/{id}")]
        public async Task<ActionResult<IEnumerable<CertificationReadDTOs>>> GetUserCertifications(int id)
        {
            var certifications = await _context.Certification.Where(c => c.UserId == id).ToListAsync();

            if (!certifications.Any())
            {
                return NotFound();
            }

            var certificationDTOs = _mapper.Map<IEnumerable<CertificationReadDTOs>>(certifications);
            return Ok(certificationDTOs);
        }

        // PUT: api/Certifications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertification(int id, CertificationUpdateDTOs certificationUpdateDTO)
        {
            if (id != certificationUpdateDTO.CertificationId)
            {
                return BadRequest();
            }

            var certification = _mapper.Map<Certification>(certificationUpdateDTO);
            _context.Entry(certification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificationExists(id))
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

        // POST: api/Certifications
        [HttpPost]
        public async Task<ActionResult<CertificationReadDTOs>> PostCertification(CertificationCreateDTOs certificationCreateDTO)
        {
            var certification = _mapper.Map<Certification>(certificationCreateDTO);
            _context.Certification.Add(certification);
            await _context.SaveChangesAsync();

            var certificationReadDTO = _mapper.Map<CertificationReadDTOs>(certification);
            return CreatedAtAction("GetCertification", new { id = certificationReadDTO.CertificationId }, certificationReadDTO);
        }

        // DELETE: api/Certifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertification(int id)
        {
            var certification = await _context.Certification.FindAsync(id);
            if (certification == null)
            {
                return NotFound();
            }

            _context.Certification.Remove(certification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertificationExists(int id)
        {
            return _context.Certification.Any(e => e.CertificationId == id);
        }
    }
}
