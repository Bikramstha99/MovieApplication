using System.ComponentModel.DataAnnotations;

namespace MovieApplication.Models.Dto
{
    public class UpdateMovie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }

    }
}
