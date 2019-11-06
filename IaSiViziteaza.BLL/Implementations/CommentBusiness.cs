using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.BLL.DTO;
using IaSiViziteaza.DAL.ORC;
using IaSiViziteaza.DAL.ORC.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IaSiViziteaza.BLL.Implementations
{
    public class CommentBusiness : ICommentBusiness
    {
        private readonly IRepositoryORC _repository;

        public CommentBusiness(IRepositoryORC repository)
        {
            _repository = repository;
        }
        public bool AddComment(CommentDTO commentDTO)
        {
            var user = _repository.GetUserByEmail(commentDTO.UserEmail);
            if (_repository.CheckUserPriority(user, 10) ==false && _repository.CheckUserPriority(user, 20) == false)
                return false;

            //var attraction = _repository.GetEntityById<Attraction>(commentDTO.AttractionId);

            //if(null == attraction.Comments)
            //{
            //    attraction.Comments = new List<Comment>();
            //}
            
            Comment comment = new Comment()
            {
                Attraction = new Attraction() { Id = commentDTO.AttractionId },
                User = user,
                CommentContent = commentDTO.CommentContent,
            };
            _repository.AddComment(comment);

            return true;
        }

        public bool DeleteCommentById(int id)
        {
            //var x = _repository.GetUserByEmail(userEmail);
            //if (_repository.CheckUserPriority(x, 20)==false)
            //    return false;

            return _repository.Delete<Comment>(id);
        }


        public IList<CommentReturnDTO> GetCommentsByAttractionId(int attractionId)
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

        public void UpdateCommentById(int id, bool status)
        {
            _repository.UpdateCommentById(id, status);
        }
    }
}
