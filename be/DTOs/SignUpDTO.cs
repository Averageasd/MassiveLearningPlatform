using System.ComponentModel.DataAnnotations;

namespace be.DTOs
{
    public class SignUpDTO
    {
        [Required]
        [StringLength(20, ErrorMessage = "Username length must be beween 5 and 20 characters", MinimumLength = 5)]
        public string? UserName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 30 characters")]
        public string? Password { get; set; }

        [Required]
        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120")]
        public int Age { get; set; }
    }
}
