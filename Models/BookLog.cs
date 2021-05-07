using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models
{
    public enum DeliveryStatus{ 
        Returned,
        Borrowed
    }
    public class BookLog
    {
        public string bookId { set; get; }

        public string bookName { set; get; }

        public string bookAuthor { set; get; }
        public DeliveryStatus Status { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
