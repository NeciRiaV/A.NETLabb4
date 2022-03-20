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
    public class HobbyController : ControllerBase
    {
        private ILabb4API<Hobby> _labb4Hobby;
        public HobbyController(ILabb4API<Hobby> labb4Hobby)
        {
            _labb4Hobby = labb4Hobby;
        }

        //GET ALL HOBBIES
        [HttpGet]
        public async Task<IActionResult> GetAllHobbies()
        {
            try
            {
                return Ok(await _labb4Hobby.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: Could not retrivedata from database.....");
            }
        }
    }
}
