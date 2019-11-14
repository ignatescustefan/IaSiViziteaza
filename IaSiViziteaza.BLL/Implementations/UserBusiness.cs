using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.BLL.DTO;
using IaSiViziteaza.DAL.ORC;
using IaSiViziteaza.DAL.ORC.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Implementations
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IRepositoryORC _repository;
        private readonly int NormalUser =1;
        private readonly int AdminUser = 2;

        public UserBusiness(IRepositoryORC repository)
        {
            _repository = repository;
        }

        public bool AddAdministratorUser(UserRegisterDTO userRegisterDTO)
        {
            if (_repository.FindUserByEmail(userRegisterDTO.Email) == true)
            {
                return false;
            }


            var user = new User()
            {
                Email = userRegisterDTO.Email,
                Password = userRegisterDTO.Password,
                FirstName = userRegisterDTO.FirstName,
                LastName = userRegisterDTO.LastName,
                PhoneNumber = userRegisterDTO.PhoneNumber,
            };
            _repository.AddUser(user);

            var user_id = _repository.GetUserByEmail(userRegisterDTO.Email).Id;
            _repository.AddUserToRight(user_id, AdminUser);

            return true;
        }

        public bool AddNormalUser(UserRegisterDTO userRegisterDTO)
        {
            if (_repository.FindUserByEmail(userRegisterDTO.Email) == true)
            {
                return false;
            }


            var user = new User()
            {
                Email = userRegisterDTO.Email,
                Password = userRegisterDTO.Password,
                FirstName = userRegisterDTO.FirstName,
                LastName = userRegisterDTO.LastName,
                PhoneNumber = userRegisterDTO.PhoneNumber,
            };
            _repository.AddUser(user);

            var user_id = _repository.GetUserByEmail(userRegisterDTO.Email).Id;
            _repository.AddUserToRight(user_id, NormalUser);
            return true;
        }

        public bool CheckUserCredentials(UserLoginDTO userLoginDTO)
        {
            var x = _repository.GetUserByEmailAndPassword(userLoginDTO.Email, userLoginDTO.Password);
            if (null != x)
                return true;
            return false;
        }

        public bool CheckUserPriority(string email)
        {
            var x = _repository.GetUserByEmail(email);
            if(null==x)
            {
                return false;
            }
            if (_repository.CheckUserPriority(x, 20) == true)
            {
                return true;
            }
            return false;
        }

        public IList<User> Get()
        {
            return _repository.GetUsers();
        }

        public UserReturnDTO GetUserByEmail(string email)
        {
            var x= _repository.GetUserByEmail(email);
            return new UserReturnDTO()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber
            };
        }

        public bool UpdateUserInformation(UserUpdateDTO userUpdateDTO)
        {
            var x = _repository.GetUserByEmail(userUpdateDTO.CurrentEmail);
            if (null == x)
                return false;

            if (_repository.FindUserByEmail(userUpdateDTO.NewEmail) == true)
                return false;

            User user = new User()
            {
                Email = userUpdateDTO.NewEmail,
                PhoneNumber = userUpdateDTO.PhoneNumber,
                Password = userUpdateDTO.NewPassword
            };
            _repository.UpdateUserInformation(user,userUpdateDTO.CurrentEmail);
            return true;
        }
    }
}
