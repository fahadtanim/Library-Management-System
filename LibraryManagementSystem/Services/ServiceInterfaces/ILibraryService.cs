using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services.ServiceInterfaces
{
    public interface ILibraryService:IService<OutputResult<Library>, InsertLibraryDto, UpdateLibraryDto>
    {
        TokenOutputResult SignIn(string username, string password);
    }
}
