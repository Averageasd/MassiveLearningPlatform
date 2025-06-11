using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace be.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Username length must be beween 5 and 20 characters", MinimumLength = 5)]
        public string? UserName { get; set; }

        [Required]
        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120")]
        public int Age { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 30 characters")]
        public string? Password { get; set; }

        [BindNever]   
        public DateTime DateJoin { get; set; } = DateTime.Now;
    }
}
