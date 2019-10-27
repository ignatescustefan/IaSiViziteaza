using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.DAL
{
    public class User:BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public ICollection<UserAccessRight> UserAccessRights { get; set; }
        public ICollection<Attraction> Attractions { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
