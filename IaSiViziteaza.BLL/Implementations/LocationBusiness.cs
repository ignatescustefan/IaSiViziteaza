using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.DAL;
using IaSiViziteaza.DAL.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Implementations
{
    public class LocationBusiness : ILocationBusiness
    {
        private readonly IRepository _repository;

        public LocationBusiness(IRepository repository)
        {
            _repository = repository;
        }
        
        public void AddLocation(Location location)
        {
            _repository.Add<Location>(location);
        }

        public Location GetLocationById(Guid id)
        {
            return _repository.GetEntityById<Location>(id);
        }
    }
}
