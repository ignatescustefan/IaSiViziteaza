using IaSiViziteaza.DAL.ORC;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Abstractions
{
    public interface ILocationBusiness
    {
        //LocationDTO
        void AddLocation(Location location);
        Location GetLocationById(int id);
    }
}
