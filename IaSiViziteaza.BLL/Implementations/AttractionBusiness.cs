using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.BLL.DTO;
using IaSiViziteaza.DAL.ORC;
using IaSiViziteaza.DAL.ORC.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IaSiViziteaza.BLL.Implementations
{
    public class AttractionBusiness: IAttractionBusiness
    {
        private readonly IRepositoryORC _repository;

        public AttractionBusiness(IRepositoryORC repository)
        {
            _repository = repository;
        }

        public bool AddAttraction(AttractionDTO attractionDTO)
        {
            User user = _repository.GetUserByEmail(attractionDTO.EmailUser);
            if (_repository.CheckUserPriority(user, 20) == false)
                return false;
            AttractionType attractionType = _repository.GetAttractionTypeByTitle(attractionDTO.Title);
            Location location = new Location()
            {
                Address = attractionDTO.Address,
                PostalCode = attractionDTO.PostalCode
            };
            _repository.AddAttraction(new Attraction()
            {
                AttractionType = attractionType,
                User = user,
                Name = attractionDTO.Name,
                Description = attractionDTO.Description,
                Rating = 0,
                PhoneNumber = attractionDTO.PhoneNumber,
                OpenTime = attractionDTO.OpenTime,
                CloseTime = attractionDTO.CloseTime,
                CreateAtractionTime = DateTime.Now,
                Location = location,
                ImagePath = @attractionDTO.Image,
            });
            return true;

        }

        public bool DeleteAttractionById(int id)
        {
           return _repository.Delete<Attraction>(id);
        }

        public IList<AttractionReturnDTO> GetAttraction()
        {
            var x = _repository.GetAttractions()
                .Select(p => new AttractionReturnDTO()
                {
                    AttractionId = p.Id,
                    Address = p.Location.Address,
                    CloseTime = p.CloseTime,
                    PhoneNumber = p.PhoneNumber,
                    CreateAtractionTime = p.CreateAtractionTime,
                    Description = p.Description,
                    FirstNameUser = p.User.FirstName,
                    LastNameUser = p.User.LastName,
                    Image = p.ImagePath,
                    Name = p.Name,
                    Rating = p.Rating,
                    OpenTime = p.OpenTime,
                    PostalCode = p.Location.PostalCode,
                    Title = p.AttractionType.Title
                })
                .OrderBy(test=>test.Name)
                .ToList();


            return x;
        }

        public AttractionReturnDTO GetAttractionById(int id)
        {
            return _repository.GetAttractions()
                .Where(att => att.Id == id)
                .Select(p => new AttractionReturnDTO()
                {
                    AttractionId = p.Id,
                    Address = p.Location.Address,
                    CloseTime = p.CloseTime,
                    PhoneNumber = p.PhoneNumber,
                    CreateAtractionTime = p.CreateAtractionTime,
                    Description = p.Description,
                    FirstNameUser = p.User.FirstName,
                    LastNameUser = p.User.LastName,
                    Image = p.ImagePath,
                    Name = p.Name,
                    Rating = p.Rating,
                    OpenTime = p.OpenTime,
                    PostalCode = p.Location.PostalCode,
                    Title = p.AttractionType.Title
                })
                .FirstOrDefault();
        }

        public IList<AttractionReturnDTO> GetAttractionsByType(string attractionTitle)
        {
            var x = _repository.GetAttractionsByType(attractionTitle)
                .Select(p => new AttractionReturnDTO()
                {
                    AttractionId = p.Id,
                    Address = p.Location.Address,
                    CloseTime = p.CloseTime,
                    PhoneNumber = p.PhoneNumber,
                    CreateAtractionTime = p.CreateAtractionTime,
                    Description = p.Description,
                    FirstNameUser = p.User.FirstName,
                    LastNameUser = p.User.LastName,
                    Image = p.ImagePath,
                    Name = p.Name,
                    Rating = p.Rating,
                    OpenTime = p.OpenTime,
                    PostalCode = p.Location.PostalCode,
                    Title = p.AttractionType.Title
                })
                .ToList();


            return x;
        }

        public void UpdateRatingAttractionById(int id, bool status)
        {
            _repository.UpdateRatingAttractionById(id, status);
        }
    }
}
