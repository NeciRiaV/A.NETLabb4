using A.NETLabb4.API.Services;
using A.NETLabb4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A.NETLabb4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILabb4API<User> _labb4User;
        public UserController(ILabb4API<User> labb4User)
        {
            _labb4User = labb4User;
        }

        //GET ALL USERS
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _labb4User.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: Could not retrive data from database.....");
            }              
        }
    }
}
