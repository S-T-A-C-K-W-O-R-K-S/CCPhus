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

        public async Task<Avatar> GetAvatar(int id)
        {
            var avatar = await _context.Avatars.FirstOrDefaultAsync(a => a.Id == id);
            return avatar;
        }

        public async Task<IEnumerable<Avatar>> GetAvatars()
        {
            var avatars = await _context.Avatars.ToListAsync();
            return avatars;
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
            var user = await _context.Users.Include(a => a.Avatars).Include(s => s.Scripts).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(a => a.Avatars).Include(s => s.Scripts).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
