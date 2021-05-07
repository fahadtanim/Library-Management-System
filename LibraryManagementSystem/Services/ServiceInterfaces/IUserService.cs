using LibraryManagementSystem.Models;
using LibraryManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.ServiceInterfaces
{
    public interface IUserService:IService<OutputResult<User>,InsertUserDto, UpdateUserDto>
    {
        Task<OutputResult<User>> GetAllFromLibrary(string id,int pageNumber);
        OutputResult<User> GetByEmail(string libraryId, string email);
    }
}
