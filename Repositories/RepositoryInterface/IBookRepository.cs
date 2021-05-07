using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories.RepositoryInterfaces
{
    public interface IBookRepository:IRepository<Book>
    {
          Task<DBOutputList<Book>> GetAllByLibraryId(string libraryId, int pageNumber);
    }
}