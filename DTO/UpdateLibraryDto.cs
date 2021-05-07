using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManagementSystem.DTO
{
    public class UpdateLibraryDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
