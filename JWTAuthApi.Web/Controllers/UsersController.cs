using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JWTAuthApi.Core.Interfaces;
using JWTAuthApi.Core.Models;
using JWTAuthApi.Services.Services;
using JWTAuthApi.Web.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(UserRegisterDto userRegisterDto)
        {
            var user = _mapper.Map<User>(userRegisterDto);
            var userId = await _userService.AddAsync(user);
            return StatusCode(201, userId);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdAsync(int userId)
        {
            var user = await _userService.GetByIdAsync(userId);
            var userDetailsDto = _mapper.Map<UserDetailsDto>(user);
            return Ok(userDetailsDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            var userDetailsDtos = _mapper.Map<List<UserDetailsDto>>(users);
            return Ok(userDetailsDtos);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateAsync(int userId, UserUpdateDto userUpdateDto)
        {
            var updatedUser = _mapper.Map<User>(userUpdateDto);
            updatedUser.Id = userId;
            await _userService.UpdateAsync(updatedUser);
            return Ok();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(int userId)
        {
            await _userService.DeleteAsync(userId);
            return Ok();
        }
    }
}
