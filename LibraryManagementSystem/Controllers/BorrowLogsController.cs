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
    public class BorrowLogsController : ControllerBase
    {
        private IBorrowLogService BorrowLogService { set; get; }

        public BorrowLogsController(IBorrowLogService borrowLogService)
        {
            this.BorrowLogService = borrowLogService;
        }
        // GET: api/<BorrowLogsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BorrowLogsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("library/{libraryId}/{pageNumber}")]
        public async Task<OutputResult<BorrowLog>> GetAllFromLibrary(string libraryId, int pageNumber)
        {
            return await this.BorrowLogService.GetAllByLibraryId(libraryId, pageNumber);
        }
        // POST api/<BorrowLogsController>
        [HttpPost]
        public OutputResult<BorrowLog> Post(InsertBorrowLogDto insertBorrowLogDto)
        {
            return this.BorrowLogService.Insert(insertBorrowLogDto);
        }

        // PUT api/<BorrowLogsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BorrowLogsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
