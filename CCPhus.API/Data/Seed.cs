using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CCPhus.API.Models;
using Newtonsoft.Json;

namespace CCPhus.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedRootUsers()
        {
            var rootUsersData = System.IO.File.ReadAllText("Data/SeedRootUsersData.json");
            var rootUsers = JsonConvert.DeserializeObject<List<User>>(rootUsersData);
            foreach (var rootUser in rootUsers)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("root", out passwordHash, out passwordSalt);

                rootUser.PasswordHash = passwordHash;
                rootUser.PasswordSalt = passwordSalt;

                _context.Users.Add(rootUser);
            }

            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var HMAC = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = HMAC.Key;
                passwordHash = HMAC.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
