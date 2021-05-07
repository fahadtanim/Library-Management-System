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
    [AllowAnonymous]
    public class LibrariesController : ControllerBase
    {
        private ILibraryService LibraryService { set; get; }

        public LibrariesController(ILibraryService libraryService)
        {
            this.LibraryService = libraryService;
        }
        // GET: api/<LibrariesController>
        [HttpGet]
        public OutputResult<Library> Get()
        {
            OutputResult<Library> outputResult = new OutputResult<Library>();
            outputResult.Status = "FAILED";
            outputResult.Message = "Not Allowed";
            return outputResult;
        }

        // GET api/<LibrariesController>/5
        [HttpGet("{id}")]
        public OutputResult<Library> Get(string id)
        {
            return this.LibraryService.Get(id);
        }

        [HttpPost("signin")]
        public TokenOutputResult SignIn(UserCredentialsDto userCredentialsDto)
        {
            return this.LibraryService.SignIn(userCredentialsDto.Username, userCredentialsDto.Password);
        }

        // POST api/<LibrariesController>/register
        [HttpPost]
        public OutputResult<Library> Post(InsertLibraryDto LibraryDto)
        {
            return this.LibraryService.Insert(LibraryDto);
        }

        // PUT api/<LibrariesController>/5
        public OutputResult<Library> Put(string id, [FromBody] UpdateLibraryDto updateLibraryDto)
        {
            return this.LibraryService.Update(id, updateLibraryDto);
            //return id;
        }

        // DELETE api/<LibrariesController>/5
        [HttpDelete("{id}")]
        public OutputResult<Library> Delete(string id)
        {
            return this.LibraryService.Delete(id);
        }
    }
}
