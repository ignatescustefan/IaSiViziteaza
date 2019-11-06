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
        private readonly int NormalUser =20;
        private readonly int AdminUser = 30;
     //   private readonly Guid MaxUser = Guid.Parse("15da1bd7-9832-4426-fbc3-08d706cf10c5");

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

            int id = new int();

            UserAccessRight userAccessRight = new UserAccessRight()
            {
                AccessRightId = AdminUser,
                UserId = id
            };
            var user = new User()
            {
                Id = id,
                Email = userRegisterDTO.Email,
                Password = userRegisterDTO.Password,
                FirstName = userRegisterDTO.FirstName,
                LastName = userRegisterDTO.LastName,
                PhoneNumber = userRegisterDTO.PhoneNumber,
                UserAccessRights = new List<UserAccessRight>()
            };
            user.UserAccessRights.Add(userAccessRight);
            _repository.Add(user);
            
            return true;
        }

        public bool AddNormalUser(UserRegisterDTO userRegisterDTO)
        {
            if (_repository.FindUserByEmail(userRegisterDTO.Email) == true)
            {
                return false;
            }

            int id = new int();

            UserAccessRight userAccessRight = new UserAccessRight()
            {
                AccessRightId = NormalUser,
                UserId = id
            };

            var user = new User()
            {
                Id = id,
                Email = userRegisterDTO.Email,
                Password = userRegisterDTO.Password,
                FirstName = userRegisterDTO.FirstName,
                LastName = userRegisterDTO.LastName,
                PhoneNumber = userRegisterDTO.PhoneNumber,
                UserAccessRights = new List<UserAccessRight>()
            };
            user.UserAccessRights.Add(userAccessRight);
            _repository.Add(user);
            return true;
        }

        public bool CheckUserCredentials(UserLoginDTO userLoginDTO)
        {
            var x = _repository.GetUserByEmailAndPassword<User>(userLoginDTO.Email, userLoginDTO.Password);
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
            return _repository.Get<User>();
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
