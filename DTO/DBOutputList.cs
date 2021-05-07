using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.DTO
{
    public class DBOutputList<T>
    {
        public List<T> Output { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPage { get; set;}

        public long totalCount { get; set; }

        public long pageSize { get; set; }
    }
}
