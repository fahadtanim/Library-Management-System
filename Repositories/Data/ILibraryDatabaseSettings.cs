using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories.Data
{
    public interface ILibraryDatabaseSettings
    {
        string BooksCollectionName { get; set; }

        string UsersCollectionName { get; set; }
        string BorrowLogsCollectionName { get; set; }
        string LibrariesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        long PageSize { set; get; }
    }
}
