using IaSiViziteaza.BLL.DTO;
using IaSiViziteaza.BLL.Implementations;
using IaSiViziteaza.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Abstractions
{
    public interface ICommentBusiness
    {
        bool AddComment(CommentDTO commentDTO);
        IList<CommentReturnDTO> GetCommentsByAttractionId(Guid attractionId);
        IList<Comment> GetComment();
        void UpdateCommentById(Guid id, bool status);
        bool DeleteCommentById(Guid id);
    }
}
