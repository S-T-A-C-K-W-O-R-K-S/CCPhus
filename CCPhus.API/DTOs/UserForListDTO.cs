using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCPhus.API.DTOs
{
    public class UserForListDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public string AvatarURL { get; set; }
    }
}
