using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.RepositoryInterfaces;
using LibraryManagementSystem.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public class BookService : IBookService
    {
        private IBookRepository BookRepository { set; get; }
        public BookService(IBookRepository bookRepository) {
            this.BookRepository = bookRepository;
        }
        public OutputResult<Book> Insert(InsertBookDto BookDto)
        {
            OutputResult<Book> outputResult = new OutputResult<Book>();
            try
            {
                Book book = new Book();
                book.Author = BookDto.Author;
                book.Category = BookDto.Category;
                book.Name = BookDto.Name;
                book.Price = BookDto.Price;
                book.Stock = BookDto.Stock;
                book.LibraryId = BookDto.LibraryId;
                book = this.BookRepository.Create(book);

                outputResult.SingleData = book;
                outputResult.Status = "OK";
                outputResult.Message = "";
                
            }
            catch (Exception e) {
                outputResult.Status = "FAILED";
                outputResult.Message = e.Message.ToString();
            }

            return outputResult;
            
        }

        public async Task<OutputResult<Book>> GetAllFromLibrary(string id, int pageNumber)
        {
            OutputResult<Book> outputResult = new OutputResult<Book>();
            try
            {
                outputResult.MultiData =  await BookRepository.GetAllByLibraryId(id, pageNumber);
                outputResult.Status = "OK";
                outputResult.Message = "";
            }

            catch (Exception e)
            {
                outputResult.Status = "FAILED";
                outputResult.Message = e.Message.ToString();
            }

            return outputResult;
        }

        public OutputResult<Book> Get(string id)
        {
           
            OutputResult<Book> outputResult = new OutputResult<Book>();
            try
            {
                outputResult.SingleData =  this.BookRepository.Get(id);
                outputResult.Status = "OK";
                outputResult.Message = "";
            }

            catch (Exception e)
            {
                outputResult.Status = "FAILED";
                outputResult.Message = e.Message.ToString();
            }

            return outputResult;
        }

        public OutputResult<Book> Update(string id, UpdateBookDto BookDto) {
            

            OutputResult<Book> outputResult = new OutputResult<Book>();
            try
            {
                Book book = new Book();
                book.Id = id;
                book.Author = BookDto.Author;
                book.Category = BookDto.Category;
                book.Name = BookDto.Name;
                book.Price = BookDto.Price;
                book.Stock = BookDto.Stock;
                book.LibraryId = BookDto.LibraryId;
                bool result = this.BookRepository.Update(id, book);
                if (result)
                {
                    outputResult.Status = "OK";
                } else
                {
                    outputResult.Status = "Failed";
                }
                outputResult.Message = result.ToString();
            }

            catch (Exception e)
            {
                outputResult.Status = "FAILED";
                outputResult.Message = e.Message.ToString();
            }

            return outputResult;
        }

        public OutputResult<Book> Delete(string id)
        {
            
            OutputResult<Book> outputResult = new OutputResult<Book>();
            try
            {
                bool result = this.BookRepository.Remove(id);
                if (result)
                {
                    outputResult.Status = "OK";
                }
                else
                {
                    outputResult.Status = "Failed";
                }
                outputResult.Message = result.ToString();
            }

            catch (Exception e)
            {
                outputResult.Status = "FAILED";
                outputResult.Message = e.Message.ToString();
            }

            return outputResult;
        }
    
    }
}
