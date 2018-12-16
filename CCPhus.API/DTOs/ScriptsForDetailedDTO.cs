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
    }
}
