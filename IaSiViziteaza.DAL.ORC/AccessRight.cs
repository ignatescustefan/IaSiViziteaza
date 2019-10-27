using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaSiViziteaza.DAL.ORC
{
    public class AccessRight : BaseEntity
    {
        public uint Priority { get; set; }
        public ICollection<UserAccessRight> UserAccessRights { get; set; }

    }
}
