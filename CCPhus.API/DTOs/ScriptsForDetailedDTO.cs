using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCPhus.API.DTOs
{
    public class ScriptsForDetailedDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        public bool Active { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastRun { get; set; }

        // public User User { get; set; } /* fix this >> Owner */
        // public int UserId { get; set; } /* fix this >> OwnerId */

        // public ICollection<User> UsersWithAccess { get; set; }
        // many-to-many relations not supported
        //TODO: read this on how to make this work: https://blog.oneunicorn.com/2017/09/25/many-to-many-relationships-in-ef-core-2-0-part-1-the-basics/
    }
}
