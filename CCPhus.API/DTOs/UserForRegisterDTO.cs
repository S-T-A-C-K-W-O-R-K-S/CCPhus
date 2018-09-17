using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCPhus.API.DTOs
{
    public class UserForRegisterDTO
    {   [Required(ErrorMessage = "Username Is Required")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Username Must Be Between 4 And 32 Characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [StringLength(24, MinimumLength = 6, ErrorMessage = "Password Must Be Between 6 And 24 Characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
