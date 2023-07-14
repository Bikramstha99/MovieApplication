using MovieApplication.Models.Domain;
using MovieApplication.Models.Dto;

namespace MovieApplication.Repository.Interfaces
{
 
        public interface IComment
        {
            bool AddComment(AddComment addcomment);
            bool UpdateComment(UpdateComment updatecomment);
            bool deleteComment(UpdateComment deletecomment);
            UpdateComment GetCommentById(int CommentId);
            List<CommentModel> GetAllComment();
    

    }
}


