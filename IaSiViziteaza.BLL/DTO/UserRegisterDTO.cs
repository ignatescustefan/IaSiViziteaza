using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.DTO
{
    public class UserRegisterDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
