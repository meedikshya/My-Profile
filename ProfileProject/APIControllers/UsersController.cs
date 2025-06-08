using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileProject.Data;
using ProfileProject.Models;
using ProfileProject.DTOs.UserDTOs;
using ProfileProject.Repository.GenericRepository;

namespace ProfileProject.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepositories _genericrRepositories;
        private readonly IMapper _mapper;

        public UsersController(IGenericRepositories genericRepositories, IMapper mapper)
        {
            _genericrRepositories = genericRepositories;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDTOs>>> GetUser()
        {
            var users = await _genericrRepositories.SelectAll<User>();
            var userDTOs = _mapper.Map<IEnumerable<UserReadDTOs>>(users);
            return Ok(userDTOs);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTOs>> GetUser(int id)
        {
            var user = await _genericrRepositories.GetById<User>(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = _mapper.Map<UserReadDTOs>(user);
            return Ok(userDTO);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserUpdateDTOs userUpdateDTOs)
        {
            if (id != userUpdateDTOs.UserId)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(userUpdateDTOs);
            user.UserId = id;

            //_genericrRepositories.Update<User>(id, user); 
                //Entry(user).State = EntityState.Modified;

            try
            {
                await _genericrRepositories.Update<User>(id, user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExists(id))
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

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserReadDTOs>> PostUser(UserCreateDTOs userCreateDTOs)
        {
            var user = _mapper.Map<User>(userCreateDTOs);
            await _genericrRepositories.Insert<User>(user);

            var userDTO = _mapper.Map<UserReadDTOs>(user);
            return CreatedAtAction("GetUser", new { id = user.UserId }, userDTO);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _genericrRepositories.GetById<User>(id); 
            if (user == null)
            {
                return NotFound();
            }

            _genericrRepositories.GetById<User>(id);
            await _genericrRepositories.Update(id, user);

            return NoContent();
        }

        private async Task<bool> UserExists(int id)
        {
            var user = await _genericrRepositories.GetById<User>(id);
            return user != null;
        }
    }
}
