using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.DAL.ORC;
using IaSiViziteaza.DAL.ORC.Abstraction;

using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Implementations
{
    public class AttractionTypeBussines: IAttractionTypeBusiness
    {
        private readonly IRepositoryORC _repository;
        public AttractionTypeBussines(IRepositoryORC repositoryORC)
        {
            _repository = repositoryORC;
        }

        private static string ImageToBase64(string imagePath)
        {
            string base64ImageRepresentation = "";
            byte[] imageArray = System.IO.File.ReadAllBytes("AttractionTypeImages/" + imagePath);
            base64ImageRepresentation = Convert.ToBase64String(imageArray);

            return @"data:image/png;base64," + base64ImageRepresentation;
        }
        public bool AddAttractionType(AttractionType attractionType)
        {
            if (_repository.FindAttractionTypeByTitle(attractionType.Title) == true)
                return false;
            _repository.AddAttractionType(attractionType);
            return true;
            //_repositoryORC.AddAttractionType(attractionType);
            //var x = _repositoryORC.AddLocation(new DAL.ORC.Location() { });
            /*  _repositoryORC.AddAttraction(new DAL.ORC.Attraction()
              {
                  Name = "ceva",
                  Description = "o descriere",
                  OpenTime = new TimeSpan(8, 30, 0),
                  CloseTime = new TimeSpan(20, 0, 0),
                  ImagePath = "/img/ceva",
                  AttractionType = new DAL.ORC.AttractionType() { Id = 2 },
                  Location = new DAL.ORC.Location() { Address = "undeva frumos", PostalCode = 1020312 },
                  User = new DAL.ORC.User() { Id = 2 }
              });
              */

            //_repositoryORC.GetAttractions();
            // _repositoryORC.GetAttractionsByType("Muzeu");

            // var x= _repositoryORC.CheckUserPriority(new DAL.ORC.User() { Email = "dudu@mail.om" }, 40);

            //var y = _repositoryORC.GetAttractionTypeByTitle("Muzeu");
            //var z = _repositoryORC.GetUserByEmail(attractionType.Title);
            //var comm = _repositoryORC.GetCommentsByAttractionId(1);
            //var user = _repository.GetUserByEmailAndPassword("dudu@mil.om", "1234567");
        }


        public bool CheckUserPriority(string email)
        {
            var x = _repository.GetUserByEmail(email);
            return _repository.CheckUserPriority(x, 20);
        }

        public bool DeleteAttractionTypeById(int id)
        {
            return _repository.DeleteAttractionTypeById(id);
        }

        public IList<AttractionType> GetAttractionTypes()
        {
            var x=_repository.GetAttractionTypes();

            foreach(var attr in x)
            {
                if (null == attr.ImagePath)
                {
                    attr.ImagePath = @"";
                }
                attr.ImagePath = ImageToBase64(attr.ImagePath);
            }
            return x;
        }
    }
}
