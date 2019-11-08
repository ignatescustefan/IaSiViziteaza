using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IaSiViziteaza.BLL.DTO
{
    public class AttractionDTO
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EmailUser { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public uint PostalCode { get; set; }
        public string Image { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public string Base64ToImage(string base64Image)
        {
            var image = base64Image.Substring(base64Image.LastIndexOf(',') + 1);
            byte[] imageBytes = Convert.FromBase64String(image);
            // Convert byte[] to Image
            string filePath = @"..\IaSiViziteaza.FE\Frontend\src\assets\AttractionImages";
            string name = Name.Replace(' ', '_') + DateTime.Now.Day + "_"
                + DateTime.Now.Month + "_"
                + DateTime.Now.Year + "_"
                + DateTime.Now.Month + "_"
                + DateTime.Now.Hour + "_"
                + DateTime.Now.Minute + "_"
                + DateTime.Now.Second; ;
            string fullName = Path.Combine(filePath, name + ".png");
            using (var imageFile = new FileStream(fullName, FileMode.Create))
            {
                imageFile.Write(imageBytes, 0, imageBytes.Length);
                imageFile.Flush();
                return name + ".png";
            }
        }

    }
}
