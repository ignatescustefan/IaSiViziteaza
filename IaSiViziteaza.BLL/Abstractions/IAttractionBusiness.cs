using IaSiViziteaza.BLL.DTO;
using IaSiViziteaza.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.Abstractions
{
    public interface IAttractionBusiness
    {
        IList<AttractionReturnDTO> GetAttraction();
        IList<AttractionReturnDTO> GetAttractionsByType(string attractionTitle);
        AttractionReturnDTO GetAttractionById(Guid id);
        bool AddAttraction(AttractionDTO attraction);
        void UpdateRatingAttractionById(Guid id, bool status);
        bool DeleteAttractionById(Guid id);
    }
}
