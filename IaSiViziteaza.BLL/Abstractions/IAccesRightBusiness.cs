using System;
using System.Collections.Generic;
using System.Text;
using IaSiViziteaza.DAL;
using IaSiViziteaza.DAL.ORC;

namespace IaSiViziteaza.BLL.Abstractions
{
    public interface IAccessRightBusiness
    {
        bool Add(AccessRight accesRight);
    }
}
