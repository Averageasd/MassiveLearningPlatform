using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class Card
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Card answer length must be between 1 and 250 characters", MinimumLength = 1)]
        public string? FrontCard { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Card question length must be between 1 and 250 characters", MinimumLength = 1)]
        public string? BackCard { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [ForeignKey(nameof(Collection))]
        public int? CollectionId { get; set; }
        public string? ImageLink { get; set; }
        [BindNever]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
