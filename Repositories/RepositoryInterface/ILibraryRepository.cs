using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Repositories.RepositoryInterfaces
{
    public interface ILibraryRepository:IRepository<Library>
    {
        Library GetByUsername(string username);
    }
}

