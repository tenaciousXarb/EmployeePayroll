﻿using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.FormDTO
{
    public class LoginDTO
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
