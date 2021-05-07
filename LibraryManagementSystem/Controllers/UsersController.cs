using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserService UserService { set; get; }

        public UsersController(IUserService userService)
        {
            this.UserService = userService;
        }
        // GET: api/<UsersController>
        [HttpGet("library/{libraryId}/{pageNumber}")]
        public async Task<OutputResult<User>> GetAllFromLibrary(string libraryId, int pageNumber)
        {
            
            return await this.UserService.GetAllFromLibrary(libraryId,pageNumber);
            
        }

        [HttpGet("email/{libraryId}/{email}")]
        public OutputResult<User> GetAllFromLibrary(string libraryId, string email)
        {

            return this.UserService.GetByEmail(libraryId,email);

        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public OutputResult<User> Get(string id)
        {
            return this.UserService.Get(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public OutputResult<User> Post(InsertUserDto userDTO)
        {
            return this.UserService.Insert(userDTO);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public OutputResult<User> Put(string id, [FromBody] UpdateUserDto userDto)
        {
            return this.UserService.Update(id, userDto);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public OutputResult<User> Delete(string id)
        {
            return this.UserService.Delete(id);
        }
    }
}
