using Microsoft.EntityFrameworkCore;
using ProfileProject.Data;
using System.Collections.Generic;
using System.Linq;

namespace ProfileProject.Repository.GenericRepository
{
    public class GenericRepositories : IGenericRepositories
    {
        private readonly ProfileProjectContext _context;

        // Using the Parameterized Constructor, 
        //initializing the context object
        public GenericRepositories(ProfileProjectContext context)
        {
            _context = context;
        }

        //// This method will return all the Records from the Database
        public async Task<List<T>> SelectAll<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// This method will Insert the Record in the Database
        public async Task<T> Insert<T>(T instance) where T : class
        {
            await _context.Set<T>().AddAsync(instance);
            await _context.SaveChangesAsync();
            return instance;
        }

        /// This method will Update the Record in the Database
        public async Task<T> Update<T>(int id, T instance) where T : class
        {
            _context.Set<T>().Update(instance);
            await _context.SaveChangesAsync();
            return instance;
        }
    }
}