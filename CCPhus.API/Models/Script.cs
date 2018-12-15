using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCPhus.API.Models
{
    public class Script
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        public bool Active { get; set; }

        public DateTime Created { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        // public ICollection<User> Users { get; set; }
        // ef migration throws error
    }
}
