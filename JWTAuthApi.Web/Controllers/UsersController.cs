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

    }
}
