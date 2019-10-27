using IaSiViziteaza.BLL.DTO;
using IaSiViziteaza.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Abstractions
{
    public interface IUserBusiness
    {
        IList<User> Get();
        bool AddNormalUser(UserRegisterDTO userRegisterDTO);
        bool AddAdministratorUser(UserRegisterDTO userRegisterDTO);
        bool CheckUserCredentials(UserLoginDTO userLoginDTO);
        UserReturnDTO GetUserByEmail(string email);
        bool CheckUserPriority(string email);
        bool UpdateUserInformation(UserUpdateDTO userUpdateDTO);
    }
}
