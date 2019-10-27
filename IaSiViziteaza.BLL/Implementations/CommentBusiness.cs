using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.BLL.DTO;
using IaSiViziteaza.DAL;
using IaSiViziteaza.DAL.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IaSiViziteaza.BLL.Implementations
{
    public class CommentBusiness : ICommentBusiness
    {
        private readonly IRepository _repository;

        public CommentBusiness(IRepository repository)
        {
            _repository = repository;
        }
        public bool AddComment(CommentDTO commentDTO)
        {
            var user = _repository.GetUserByEmail(commentDTO.UserEmail);
            if (_repository.CheckUserPriority(user, 10) ==false && _repository.CheckUserPriority(user, 20) == false)
                return false;

            var attraction = _repository.GetEntityById<Attraction>(commentDTO.AttractionId);

            if(null == attraction.Comments)
            {
                attraction.Comments = new List<Comment>();
            }
            
            Comment comment = new Comment()
            {
                Attraction = attraction,
                User = user,
                CommentContent = commentDTO.CommentContent,
                Id = new Guid(),
                PostingDate = DateTime.Now,
                Rating = 0,
            };
            attraction.Comments.Add(comment);
            _repository.Add<Comment>(comment);

            return true;
        }

        public bool DeleteCommentById(Guid id)
        {
            //var x = _repository.GetUserByEmail(userEmail);
            //if (_repository.CheckUserPriority(x, 20)==false)
            //    return false;

            return _repository.Delete<Comment>(id);
        }

        public IList<Comment> GetComment()
        {
            return _repository.Get<Comment>();
        }

        public IList<CommentReturnDTO> GetCommentsByAttractionId(Guid attractionId)
        {
            var x = _repository.GetCommentsByAttractionId(attractionId)
                .Select(p => new CommentReturnDTO()
                {
                    CommentId = p.Id,
                    CommentContent = p.CommentContent,
                    FirstNameUser = p.User.FirstName,
                    LastNameUser = p.User.LastName,
                    PostingDate = p.PostingDate,
                    Rating = p.Rating
                })
                .ToList();
            return x;
        }

        public void UpdateCommentById(Guid id, bool status)
        {
            _repository.UpdateCommentById(id, status);
        }
    }
}
