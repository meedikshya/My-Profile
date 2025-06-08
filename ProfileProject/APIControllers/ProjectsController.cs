using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileProject.Data;
using ProfileProject.Models;
using ProfileProject.DTOs.ProjectDTOs;

namespace ProfileProject.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProfileProjectContext _context;
        private readonly IMapper _mapper;

        public ProjectsController(ProfileProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectReadDTOs>>> GetProjects()
        {
            var projects = await _context.Project.ToListAsync();
            var projectDTOs = _mapper.Map<IEnumerable<ProjectReadDTOs>>(projects);
            return Ok(projectDTOs);
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectReadDTOs>> GetProject(int id)
        {
            var project = await _context.Project.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            var projectDTO = _mapper.Map<ProjectReadDTOs>(project);
            return Ok(projectDTO);
        }

        // GET: api/Projects/User/5
        [HttpGet("Users/{id}")]
        public async Task<ActionResult<IEnumerable<ProjectReadDTOs>>> GetUserProjects(int id)
        {
            var projects = await _context.Project
                                         .Where(p => p.UserId == id)
                                         .ToListAsync();

            if (!projects.Any())
            {
                return NotFound();
            }

            var projectDTOs = _mapper.Map<IEnumerable<ProjectReadDTOs>>(projects);
            return Ok(projectDTOs);
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, ProjectUpdateDTOs projectUpdateDTO)
        {
            if (id != projectUpdateDTO.ProjectId)
            {
                return BadRequest();
            }

            var project = _mapper.Map<Project>(projectUpdateDTO);
            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<ProjectReadDTOs>> PostProject(ProjectCreateDTOs projectCreateDTO)
        {
            var project = _mapper.Map<Project>(projectCreateDTO);
            _context.Project.Add(project);
            await _context.SaveChangesAsync();

            var projectReadDTO = _mapper.Map<ProjectReadDTOs>(project);
            return CreatedAtAction("GetProject", new { id = project.ProjectId }, projectReadDTO);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Project.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectId == id);
        }
    }
}
