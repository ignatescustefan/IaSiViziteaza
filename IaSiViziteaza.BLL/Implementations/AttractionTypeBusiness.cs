using IaSiViziteaza.BLL.Abstractions;
using IaSiViziteaza.DAL;
using IaSiViziteaza.DAL.Abstraction;

using IaSiViziteaza.DAL.ORC.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Implementations
{
    public class AttractionTypeBussines: IAttractionTypeBusiness
    {
        private readonly IRepository _repository;
        private readonly IRepositoryORC _repositoryORC;
        public AttractionTypeBussines(IRepository repository,IRepositoryORC repositoryORC)
        {
            _repository = repository;
            _repositoryORC = repositoryORC;
        }

        public bool AddAttractionType(AttractionType attractionType)
        {
            if (_repository.FindAttractionByTitle(attractionType.Title) == true)
                return false;
            _repository.Add<AttractionType>(attractionType);
            return true;
        }

    

        public void AddAttractionType(DAL.ORC.AttractionType attractionType, bool val)
        {
            _repositoryORC.AddAttractionType(attractionType);

        }

        public bool CheckUserPriority(string email)
        {
            var x = _repository.GetUserByEmail(email);
            return _repository.CheckUserPriority(x, 20);
        }

        public bool DeleteAttractionTypeById(Guid id)
        {
            return _repository.Delete<AttractionType>(id);
        }

        public IList<AttractionType> GetAttractionTypes()
        {
            var x=_repository.Get<AttractionType>();
            foreach(var attr in x)
            {
                if (null == attr.ImagePath)
                {
                    attr.ImagePath = @"";
                }
            }
            return x;
        }
    }
}
