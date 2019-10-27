using IaSiViziteaza.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Abstractions
{
    public interface ILocationBusiness
    {
        //LocationDTO
        void AddLocation(Location location);
        Location GetLocationById(Guid id);
    }
}
