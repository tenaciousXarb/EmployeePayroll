using BLL.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.FormDTO
{
    public class EmployeeRegistrationDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Pincode { get; set; }
        [Required]
        public string? Degree { get; set; }
        [Required]
        [Display(Name = "Bank Account")]
        public string? BankAccount { get; set; }
        [Required]
        [Unique(ErrorMessage = "Username has to be unique!")]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
