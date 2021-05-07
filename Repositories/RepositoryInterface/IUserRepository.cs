using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.DTO;
using LibraryManagementSystem.Models;
namespace LibraryManagementSystem.Repositories.RepositoryInterfaces
{
    public interface IUserRepository: IRepository<User>
    {
        Task<DBOutputList<User>> GetAllByLibraryId(string libraryId,int pageNumber);

        User GetByEmail(string libraryId, string email);
    }
}
