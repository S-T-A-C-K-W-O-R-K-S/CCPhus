using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCPhus.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CCPhus.API.Data
{
    public class EntityRepository : IEntityRepository
    {
        private readonly DataContext _context;

        public EntityRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
            return photo;
        }

        public async Task<IEnumerable<Photo>> GetPhotos()
        {
            var photos = await _context.Photos.ToListAsync();
            return photos;
        }

        public async Task<Script> GetScript(int id)
        {
            var script = await _context.Scripts.FirstOrDefaultAsync(s => s.Id == id);
            return script;
        }

        public async Task<IEnumerable<Script>> GetScripts()
        {
            var scripts = await _context.Scripts.ToListAsync();
            return scripts;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).Include(s => s.Scripts).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).Include(s => s.Scripts).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
