using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCPhus.API.Data;
using CCPhus.API.DTOs;
using CCPhus.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCPhus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDTO)
        {
            if (await _repo.UserExists(userForRegisterDTO.Username).ConfigureAwait(false)) return BadRequest("User Already Exists");

            var userToCreate = new User
            {
                Username = userForRegisterDTO.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDTO.Password).ConfigureAwait(false);

            return StatusCode(201);
        }
    }
}
