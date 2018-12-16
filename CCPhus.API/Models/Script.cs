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
        public DateTime LastRun { get; set; }

        public string Owner { get; set; }
        public int OwnerId { get; set; }

        //public ICollection<User> PermittedUsers { get; set; }
        // many-to-many relations not supported
        // read this on how to make this work: https://blog.oneunicorn.com/2017/09/25/many-to-many-relationships-in-ef-core-2-0-part-1-the-basics/
    }
}
