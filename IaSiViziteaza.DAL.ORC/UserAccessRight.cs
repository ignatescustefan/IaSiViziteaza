using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaSiViziteaza.DAL.ORC
{
    public class UserAccessRight
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid AccessRightId { get; set; }
        public AccessRight AccessRight { get; set; }
    }
}
