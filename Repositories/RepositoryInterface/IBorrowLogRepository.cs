using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories.RepositoryInterfaces
{
    public interface IBorrowLogRepository:IRepository<BorrowLog>
    {
        
        Task<DBOutputList<BorrowLog>> GetAllByLibraryId(string libraryId, int pageNumber);
        Task<DBOutputList<BorrowLog>> Search(string libraryId, string userId, DateTime borrowDate, BorrowStatus borrowStatus, int pageNumber);
    }
}
