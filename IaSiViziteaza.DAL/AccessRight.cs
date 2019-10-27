using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.DAL
{
    public class AccessRight:BaseEntity
    {
        public uint Priority { get; set; }
        public  ICollection<UserAccessRight> UserAccessRights { get; set; }

    }
}
