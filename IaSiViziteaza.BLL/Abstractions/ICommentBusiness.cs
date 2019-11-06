using IaSiViziteaza.BLL.DTO;
using IaSiViziteaza.BLL.Implementations;
using IaSiViziteaza.DAL;
using IaSiViziteaza.DAL.ORC;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Abstractions
{
    public interface ICommentBusiness
    {
        bool AddComment(CommentDTO commentDTO);
        IList<CommentReturnDTO> GetCommentsByAttractionId(int attractionId);
        void UpdateCommentById(int id, bool status);
        bool DeleteCommentById(int id);
    }
}
