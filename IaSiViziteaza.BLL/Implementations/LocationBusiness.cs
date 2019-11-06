using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.DAL.ORC;
using IaSiViziteaza.DAL.ORC.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Implementations
{
    public class LocationBusiness : ILocationBusiness
    {
        private readonly IRepositoryORC _repository;

        public LocationBusiness(IRepositoryORC repository)
        {
            _repository = repository;
        }
        
        public void AddLocation(Location location)
        {
            _repository.AddLocation(location);
        }

        public Location GetLocationById(int id)
        {
            return _repository.GetEntityById<Location>(id);
        }
    }
}
