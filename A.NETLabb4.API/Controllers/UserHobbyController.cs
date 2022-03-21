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
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingelUser(int id)
        {
            var result = await _labb4UsHo.GetSingelUser(id);
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound();
        }

        //GET ALL LINKS TO SINGEL USER
        [HttpGet("{getlinks}")]
        public async Task<ActionResult<UserHobby>> GetLinks(int id)
        {
            var result = await _labb4UsHo.GetLinks(id);
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound();
        }

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
                return CreatedAtAction(nameof(AddNewUserHobby), new { id = createdNewUserHobby.UserID }, createdNewUserHobby);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //UPDATE LINK 
        [HttpPut("{id}")]
        public async Task<ActionResult<UserHobby>> UpdateLink(int id, UserHobby UsHo)
        {
            try
            {
                if (id != UsHo.UserHobbyID)
                {
                    return BadRequest("UserHobby ID doesn't exist....");
                }
                var LinkToUpdate = await _labb4UsHo.GetSingel(id);
                if (LinkToUpdate == null)
                {
                    return NotFound($"UserHobby with ID {id} not found....");
                }
                return await _labb4UsHo.Update(UsHo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ("Error: could not update UserHobby in database"));
            }
        }
    }
}
