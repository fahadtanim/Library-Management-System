using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.ServiceInterfaces
{
    public interface IBookService:IService<OutputResult<Book>, InsertBookDto,UpdateBookDto>
    {
        Task<OutputResult<Book>> GetAllFromLibrary(string id, int pageNumber);
    }
}
