using IaSiViziteaza.DAL.ORC;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Abstractions
{
    public interface IAttractionTypeBusiness
    {
        IList<AttractionType> GetAttractionTypes();
        bool AddAttractionType(AttractionType attractionType);

        bool CheckUserPriority(string email);
        bool DeleteAttractionTypeById(int id);
    }
}
