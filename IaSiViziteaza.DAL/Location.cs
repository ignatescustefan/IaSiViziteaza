using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.DAL
{
    public class Location:BaseEntity
    {
        public string Address { get; set; }
        public uint PostalCode { get; set; }

        public Guid LocationOfAttractionId { get; set; }
        public Attraction Attraction { get; set; }
    }
}
