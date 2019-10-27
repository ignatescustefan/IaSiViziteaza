using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.DAL
{
    public class UserAccessRight
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid AccessRightId { get; set; }
        public AccessRight AccessRight { get; set; }
    }
}
