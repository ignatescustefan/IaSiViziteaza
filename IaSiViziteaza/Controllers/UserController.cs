using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.BLL.DTO;
using IaSiViziteaza.DAL;
using Microsoft.AspNetCore.Mvc;

namespace IaSiViziteaza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _business;

        public UserController(IUserBusiness bussines)
        {
            _business = bussines;
        }
        // GET api/user
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_business.Get());
        }

        // GET api/user/email
        [HttpGet("{email}")]
        public ActionResult<UserReturnDTO> Get(string email)
        {
            var x = _business.GetUserByEmail(email);
            x.AdminStatus = _business.CheckUserPriority(email);
            return x;
        }

        // POST api/user
        [HttpPost]
        public ActionResult PostNormalUser([FromBody] UserRegisterDTO userRegisterDTO)
        {
            var x = userRegisterDTO.Email.Contains('@')
                && userRegisterDTO.Password.Length >= 6
                && !userRegisterDTO.FirstName.Equals("")
                && !userRegisterDTO.LastName.Equals("");
            if (x == true)
                return Ok(_business.AddNormalUser(userRegisterDTO));
            return Ok(x);
        }
        [Route("addAdminUser")]
        [HttpPost]
        public ActionResult PostAdminUser([FromBody] UserRegisterDTO userRegisterDTO)
        {
            var x = userRegisterDTO.Email.Contains('@')
                && userRegisterDTO.Password.Length >= 6
                && !userRegisterDTO.FirstName.Equals("")
                && !userRegisterDTO.LastName.Equals("");
            if(x==true)
              return Ok(_business.AddAdministratorUser(userRegisterDTO));
            return Ok(x);
        }

        // POST api/user/login
        [Route("login")]
        [HttpPost]
        public ActionResult LoginCheck([FromBody] UserLoginDTO userLoginDTO)
        {
            return Ok(_business.CheckUserCredentials(userLoginDTO));
        }

        // PUT api/user/5
        [Route("update")]
        [HttpPut]
        public ActionResult Put([FromBody] UserUpdateDTO userUpdateDTO)
        {
            var x = userUpdateDTO.NewPassword.Length > 6 && userUpdateDTO.NewEmail.Contains('@') == true;
            if (x == true)
                return Ok(_business.UpdateUserInformation(userUpdateDTO));
            return Ok(x);
        }

    }
}
