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
    public class UserHobbyController : ControllerBase
    {
        private ILabb4API<UserHobby> _labb4UsHo;
        public UserHobbyController(ILabb4API<UserHobby> labbUsHo)
        {
            _labb4UsHo = labbUsHo;
        }

        //GET ALL USERS AND HOBBIES
        [HttpGet]
        public async Task<IActionResult> GetAllUserHobby()
        {
            try
            {
                return Ok(await _labb4UsHo.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: Could not retrive data from database.....");
            }
        }

        //GET HOBBIES FOR SINGEL USER
        [HttpGet("{id}")]
        public async Task<ActionResult> GetHobbyForSingelUser(int id)
        {
            try
            {
                return Ok(await _labb4UsHo.GetAll(id));
            //var result = await _labb4UsHo.GetSingel(id);
            //    if (result == null)
            //    {
            //        return NotFound();
            //    }
            //    return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: Could not retrive singel User from database.....");
            }
        }
        //GET ALL LINKS TO SINGEL USER




        //ADD NEW HOBBY TO SINGEL USER
        [HttpPost]
        public async Task<ActionResult<UserHobby>> AddNewUserHobby(UserHobby newUserHobby)
        {
            try
            {
                if (newUserHobby == null)
                {
                    return BadRequest();
                }
                var createdNewUserHobby = await _labb4UsHo.Add(newUserHobby);
                return CreatedAtAction(nameof(AddNewUserHobby), new { id = createdNewUserHobby.UserID}, createdNewUserHobby);
            }
            catch (Exception)
            {
                throw;
            }
        }



        //ADD NEW LINK TO SINGEL USER AND HOBBY
    }
}
