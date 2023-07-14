using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace MovieApplication.Models.Dto
{
    public class UpdateMovie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public int Year{ get; set; }
        [Required]
        public string Country { get ; set; }
        public string? Image { get; set; }


    }
}
