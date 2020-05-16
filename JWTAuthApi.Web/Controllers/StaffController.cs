using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JWTAuthApi.Core.Entities;
using JWTAuthApi.Core.Interfaces;
using JWTAuthApi.Web.Dtos.UserDtos;
using JWTAuthApi.Web.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = RolesEntity.Admin + "," + RolesEntity.Staff)]
    public class StaffController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public StaffController(IUserService userService, IMapper mapper)
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

            

            var userDetailsDto = _mapper.Map<UserPreviewDto>(user);
            return Ok(userDetailsDto);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllAsync();
            
            var loggedInUserId = HttpContextHelper.GetIdByContextUser(HttpContext.User);
            var loggedInUser = await _userService.GetByIdAsync(loggedInUserId);
            // Filter only users with <= access level
            var loggedInUserMaxAccessLevelMax = int.Parse(loggedInUser.Policies.Where(p => p.Policy.Contains("AccessLevel")).Max(p => p.Value));
            users = users.Where(u => int.Parse(u.Policies.Where(p => p.Policy
                .Contains("AccessLevel"))
                .Max(p => p.Value)) <= loggedInUserMaxAccessLevelMax);

            var userDetailsDtos = _mapper.Map<List<UserPreviewDto>>(users);
            return Ok(userDetailsDtos);
        }
    }
}