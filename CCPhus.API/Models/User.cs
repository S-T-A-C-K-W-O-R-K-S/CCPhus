using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CCPhus.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Script> Scripts { get; set; }
    }
}
