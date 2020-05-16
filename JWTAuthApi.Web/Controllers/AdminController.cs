using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JWTAuthApi.Core.Entities;
using JWTAuthApi.Core.Interfaces;
using JWTAuthApi.Web.Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = RolesEntity.Admin)]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AdminController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetUserByIdAsync(int userId)
        {
            var user = await _userService.GetByIdAsync(userId);

            if (user == null)
            {
                return NotFound(new { message = "User doesn't exist!" });
            }

            var userDetailsDto = _mapper.Map<UserDetailsDto>(user);
            return Ok(userDetailsDto);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllAsync();
            var userDetailsDtos = _mapper.Map<List<UserDetailsDto>>(users);
            return Ok(userDetailsDtos);
        }
    }
}