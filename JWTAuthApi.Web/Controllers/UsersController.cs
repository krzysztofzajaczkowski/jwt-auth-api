using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthApi.Core.Interfaces;
using JWTAuthApi.Core.Models;
using JWTAuthApi.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(User user)
        {
            var userId = await _userService.AddAsync(user);
            return StatusCode(201, userId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int userId)
        {
            var user = await _userService.GetByIdAsync(userId);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, User updatedUser)
        {
            updatedUser.Id = id;
            await _userService.UpdateAsync(updatedUser);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
