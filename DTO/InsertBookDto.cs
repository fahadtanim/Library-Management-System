using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManagementSystem.DTO
{
    public class InsertBookDto
    {
        [Required]
        public string Name { set; get; }
        
        [Required]
        [Range(0, 1000000000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Price { get; set; }

        [Required]
        //[JsonConverter(typeof(StringEnumConverter))]
        public BookCategory Category { get; set; }

        [Required]
        public string Author { get; set; }
        
        [Required]
        [Range(0,10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Stock { get; set; }

        [Required]
        public string LibraryId { set; get; }
    }
}
