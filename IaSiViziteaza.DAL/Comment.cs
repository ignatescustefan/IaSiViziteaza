using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.DAL
{
    public class Comment:BaseEntity
    {
        public Attraction Attraction { get; set; }
        public User User { get; set; }
        public string CommentContent { get; set; }
        public DateTime PostingDate { get; set; }
        public double Rating { get; set; }
    }
}
