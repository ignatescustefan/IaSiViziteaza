using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.DTO
{
    public class CommentDTO
    {
        public Guid AttractionId { get; set; }
        public string CommentContent { get; set; }
        public string UserEmail { get; set; }
    }
}
