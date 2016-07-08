﻿using System.ComponentModel.DataAnnotations;

namespace CompanyProjects.Dal.Model
{
    class User
    {
        // --- PRIMARNI KLJUCEVI ----
        public int UserId { get; set; }

        // --- PODACI ---
        [Required]
        [StringLength(64, ErrorMessage = "Name cant be longer then 64 characters")]
        public string Name { get; set; }


        [Required]
        [StringLength(64, ErrorMessage = "Last Name cant be longer then 64 characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Username|Email Name cant be longer then 64 characters")]
        public string Email { get; set; }

        [Required]
        [StringLength(512, ErrorMessage = "Password cant be longer then 128 characters")]
        public string Password { get; set; }
    }
}
