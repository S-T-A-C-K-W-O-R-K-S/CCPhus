using CCPhus.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCPhus.API.DTOs
{
    public class UserForDetailedDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }

        public string TimeAsUser { get; set; }

        public DateTime LastActive { get; set; }

        public string AvatarURL { get; set; }
        public ICollection<AvatarsForDetailedDTO> Avatars { get; set; }
        public ICollection<ScriptsForDetailedDTO> Scripts { get; set; }
    }
}
