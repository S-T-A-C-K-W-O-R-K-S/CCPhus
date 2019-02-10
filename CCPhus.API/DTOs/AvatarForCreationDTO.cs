using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCPhus.API.DTOs
{
    public class AvatarForCreationDTO
    {
        public string URL { get; set; }
        public IFormFile File { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }

        public AvatarForCreationDTO()
        {
            DateAdded = DateTime.Now;
        }
    }
}
