using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Services.ServiceInterfaces;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private IBookService BookService { set; get; }

        public BooksController(IBookService bookService) {
            this.BookService = bookService;
        }
        // GET: api/<BooksController>
        [HttpGet("library/{libraryId}/{pageNumber}")]
        public async Task<OutputResult<Book>> GetAllFromLibrary(string libraryId,int pageNumber)
        {
            return await this.BookService.GetAllFromLibrary(libraryId, pageNumber);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public OutputResult<Book> Get(string id)
        {
            return this.BookService.Get(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public OutputResult<Book> Post(InsertBookDto BookDto)
        {
            return this.BookService.Insert(BookDto);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public OutputResult<Book> Put(string id, [FromBody] UpdateBookDto updateBookDto)
        {
            return this.BookService.Update(id, updateBookDto);
            //return id;
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public OutputResult<Book> Delete(string id)
        {
            return this.BookService.Delete(id);
        }
    }
}
