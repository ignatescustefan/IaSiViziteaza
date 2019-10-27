using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.DTO
{
    public class CommentReturnDTO
    {
        public Guid CommentId { get; set; }
        public string FirstNameUser { get; set; }
        public string LastNameUser { get; set; }
        public string CommentContent { get; set; }
        public DateTime PostingDate { get; set; }
        public double Rating { get; set; }
    }
}
