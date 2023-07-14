using MovieApplication.Repository.Interfaces;
using MovieApplication.Models.Domain;
using MovieApplication.Models.Dto;
using MovieApplication.Data;

namespace MovieApplication.Repository.Implementations
{
    public class Comment : IComment
    {
        private readonly MovieDbContext _movieDbContext;

        public Comment(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public List<CommentModel> GetAllComment()
        {
            var comment = _movieDbContext.Comments.ToList();
            return comment;
        }

        public bool AddComment(AddComment addcomment)
        {
            var comment = new CommentModel()
            {
                CommentId=addcomment.CommentId,
                CommentDesc=addcomment.CommentDecs,
                TimeStamp=addcomment.CreatedAt,
            };
            _movieDbContext.Comments.Add(comment);
            _movieDbContext.SaveChanges();
            return true;
        }
        public bool UpdateComment(UpdateComment updatecomment)
        {
            var comment = _movieDbContext.Comments.Find(updatecomment.CommentId);
            comment.CommentId = updatecomment.CommentId;
            comment.CommentDesc = updatecomment.CommentDesc;

            _movieDbContext.SaveChanges();
            return true;
        }

        public bool deleteComment(UpdateComment deletecomment)
        {
            var comment = _movieDbContext.Comments.Find(deletecomment.CommentId);
            _movieDbContext.Comments.Remove(comment);
            _movieDbContext.SaveChanges();
            return true;
        }
        public UpdateComment GetCommentById(int CommentId)
        {

            var comment = _movieDbContext.Comments.Find(CommentId);
            var viewmodel = new UpdateComment()
            {
               CommentId = comment.CommentId,
               CommentDesc=comment.CommentDesc,
            };
            return viewmodel;
        }

       
    }
}
