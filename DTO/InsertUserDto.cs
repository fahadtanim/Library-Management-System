using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManagementSystem.DTO
{
    public class InsertUserDto
    {

        [Required]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        public string Phone { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string LibraryId { get; set; }
    }
}
