using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.DAL;
using IaSiViziteaza.DAL.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Implementations
{
    public class UserAccessRightBusiness : IUserAccessRightBusiness
    {
        private readonly IRepository _repository;

        public UserAccessRightBusiness(IRepository repository)
        {
            _repository = repository;
        }

        public void Add(UserAccessRight userAccessRight)
        {
            _repository.Add(userAccessRight);
        }
    }
}
