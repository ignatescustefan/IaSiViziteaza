using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.DAL.ORC;
using IaSiViziteaza.DAL.ORC.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Implementations
{
    public class AccessRightBusiness: IAccessRightBusiness
    {
        private readonly IRepositoryORC _repository;

        public AccessRightBusiness(IRepositoryORC repository)
        {
            _repository = repository;
        }

        public bool Add(AccessRight accesRight)
        {
            _repository.AddAccesRight(accesRight);
            return true;
        }
    }
}
