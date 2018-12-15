using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCPhus.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string URL { get; set; }

        public bool IsMain { get; set; }

        public DateTime DateAdded { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
