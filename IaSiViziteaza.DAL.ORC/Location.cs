using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaSiViziteaza.DAL.ORC
{
    public class Location : BaseEntity
    {
        public string Address { get; set; }
        public uint PostalCode { get; set; }

        public Guid LocationOfAttractionId { get; set; }
        public Attraction Attraction { get; set; }
    }
}
