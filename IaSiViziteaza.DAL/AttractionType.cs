using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.DAL
{
    public class AttractionType:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Attraction> Attractions { get; set; }
    }
}
