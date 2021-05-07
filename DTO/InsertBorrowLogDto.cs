using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTO
{
    public class InsertBorrowLogDto
    {
       [Required]
        public string UserId { get; set; }

        [Required]
        public List<BookLog> BookLogs { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; }

        [Required]
        public BorrowStatus BorrowStatus { set; get; }
        
        [Required]
        public string LibraryId { get; set; }
    }
}
