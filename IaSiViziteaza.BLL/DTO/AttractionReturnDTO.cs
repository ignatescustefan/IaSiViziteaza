using System;
using System.Collections.Generic;
using System.Text;

namespace IaSiViziteaza.BLL.DTO
{
    public class AttractionReturnDTO
    {
        public int AttractionId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FirstNameUser { get; set; }
        public string LastNameUser { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public uint PostalCode { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public DateTime CreateAtractionTime { get; set; }
        public double Rating { get; set; }
        public string ImageToBase64(string imagePath)
        {
            string base64ImageRepresentation = "";
            byte[] imageArray = System.IO.File.ReadAllBytes("AttractionImages/" + imagePath);
            base64ImageRepresentation = Convert.ToBase64String(imageArray);

            return @"data:image/png;base64,"+base64ImageRepresentation;
        }
    }
}
