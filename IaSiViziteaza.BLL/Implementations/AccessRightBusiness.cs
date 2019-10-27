using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.DAL;
using IaSiViziteaza.DAL.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Implementations
{
    public class AccessRightBusiness: IAccessRightBusiness
    {
        private readonly IRepository _repository;

        public AccessRightBusiness(IRepository repository)
        {
            _repository = repository;
        }

        public bool Add(AccessRight accesRight)
        {
            _repository.Add<AccessRight>(accesRight);
            return true;
        }
    }
}
