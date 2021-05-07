using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories.Data

{
    public class LibraryDatabaseSettings : ILibraryDatabaseSettings
    {
        public string BooksCollectionName { get; set ; }
        public string UsersCollectionName { get; set; }
        public string BorrowLogsCollectionName { get; set; }
        public string LibrariesCollectionName { get; set; }
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get ; set ; }

        public long PageSize { set; get; }

        
    }
}
