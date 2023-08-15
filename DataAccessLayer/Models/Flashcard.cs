using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Flashcard
    {
        public Guid Id { get; set; }
        [Required]
        public string? Body { get; set; }
        [Required]
        public string? HiddenBody { get; set; }
    }
}
