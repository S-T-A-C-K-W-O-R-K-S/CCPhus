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
                
            }
        }
    }
}
