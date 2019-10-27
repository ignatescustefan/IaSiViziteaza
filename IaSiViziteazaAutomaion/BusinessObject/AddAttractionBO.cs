using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaSiViziteazaAutomation.BusinessObject
{
    public class AddAttractionBO
    {
        public string Title { get; set; } = "NewTitle";
        public string Name { get; set; } = "name";
        public string Description { get; set; } = "Very long description";
        public string PhoneNumber { get; set; } = "0745632148";
        public string Adress { get; set; } = "adress";
        public string PostalCode { get; set; } = "701588";
        // imagine
        public string OpenTime { get; set; } = "07:00";
        public string CloseTime { get; set; } = "20:00";
    }
}
