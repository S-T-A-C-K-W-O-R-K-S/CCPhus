using AutoMapper;
using CCPhus.API.Data;
using CCPhus.API.DTOs;
using CCPhus.API.Helpers;
using CCPhus.API.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CCPhus.API.Controllers
{
    [Authorize]
    [Route("api/company/{userId}/avatars")]
    public class AvatarsController : ControllerBase
    {
        private readonly IEntityRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;

        private Cloudinary _cloudinary;

        public AvatarsController(IEntityRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _repo = repo;
            _mapper = mapper;
            _cloudinaryConfig = cloudinaryConfig;

            Account account = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.APIKey,
                _cloudinaryConfig.Value.APISecret
            );

            _cloudinary = new Cloudinary(account);
        }

        [HttpGet("{id}", Name = "GetAvatar")]
        public async Task<IActionResult> GetAvatar(int id)
        {
            var avatarFromRepo = await _repo.GetAvatar(id);

            var avatar = _mapper.Map<AvatarForReturnDTO>(avatarFromRepo);

            return Ok(avatar);
        }

        [HttpPost]
        public async Task<IActionResult> AddAvatarForUser(int userId, [FromForm]AvatarForCreationDTO avatarForCreationDTO)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(userId);

            var file = avatarForCreationDTO.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(1000).Height(1000).Crop("fill").Gravity("face")
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            avatarForCreationDTO.URL = uploadResult.Uri.ToString();
            avatarForCreationDTO.PublicId = uploadResult.PublicId;

            var avatar = _mapper.Map<Avatar>(avatarForCreationDTO);

            if (!userFromRepo.Avatars.Any(a => a.IsMain))
                avatar.IsMain = true;

            userFromRepo.Avatars.Add(avatar);

            if (await _repo.SaveAll())
            {
                var avatarToReturn = _mapper.Map<AvatarForReturnDTO>(avatar);
                return CreatedAtRoute("GetAvatar", new { id = avatar.Id }, avatarToReturn);
            }

            return BadRequest("Could Not Upload Your Avatar");
        }
    }
}
