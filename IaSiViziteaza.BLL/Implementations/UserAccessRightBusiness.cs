using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.DAL.ORC;
using IaSiViziteaza.DAL.ORC.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Implementations
{
    public class UserAccessRightBusiness : IUserAccessRightBusiness
    {
        private readonly IRepositoryORC _repository;

        public UserAccessRightBusiness(IRepositoryORC repository)
        {
            _repository = repository;
        }

        public void Add(UserAccessRight userAccessRight)
        {
            _repository.AddUserToRight(userAccessRight.UserId,userAccessRight.AccessRightId);
        }
    }
}
