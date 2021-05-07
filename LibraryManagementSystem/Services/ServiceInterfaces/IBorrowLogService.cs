using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.ServiceInterfaces
{
    public interface IBorrowLogService:IService<OutputResult<BorrowLog>, InsertBorrowLogDto, UpdateBorrowLogDto>
    {
        
        Task<OutputResult<BorrowLog>> GetAllByLibraryId(string libraryId, int pageNumber);
        Task<OutputResult<BorrowLog>> Search(string libraryId, string userId, DateTime borrowDate, BorrowStatus borrowStatus, int pageNumber);
    }
}
