using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCPhus.API.DTOs
{
    public class AvatarForReturnDTO
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string PublicId { get; set; }

        public bool IsMain { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
