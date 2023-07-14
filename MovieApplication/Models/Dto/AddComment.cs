using Microsoft.AspNetCore.Identity;
using MovieApplication.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApplication.Models.Dto
{
    public class AddComment
    {
        public int CommentId { get; set; }
        public string? CommentDecs { get; set; }
        public string? UserName { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
