using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }  
        public int QuizCount { get; set; } = 0;
        public int PostCount { get; set; } = 0;
        public int CardCount { get; set; } = 0;
        public int CollectionCount { get; set; } = 0;

    }
}
