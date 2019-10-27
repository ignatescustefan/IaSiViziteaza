using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaSiViziteaza.DAL.ORC
{
    public class Attraction : BaseEntity
    {
        public User User { get; set; }

        public AttractionType AttractionType { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Location Location { get; set; }


        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public string PhoneNumber { get; set; }

        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }

        public DateTime CreateAtractionTime { get; set; }
    }
}