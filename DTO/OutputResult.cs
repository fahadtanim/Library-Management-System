using System;
using System.Collections.Generic;
using LibraryManagementSystem.Models;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DTO
{
    public class OutputResult<T>
    {
        public string Status { get; set; }

        public string Message { get; set; }
        public T SingleData { get; set; }

        public DBOutputList<T> MultiData { get; set; }
    }
}
