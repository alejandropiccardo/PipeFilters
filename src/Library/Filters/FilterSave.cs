using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    public class FilterSave : IFilter
    {
        /// <summary>
        /// guarda la imagen en path
        /// </summary>
        public FilterSave(string path)
        {
            this.Path=path;   
        }
        public string Path { get; set; }
        public IPicture Filter(IPicture image)
        {
            //string path2=Path;//@"x.jpg";
            PictureProvider providerinternal1 = new PictureProvider();
            providerinternal1.SavePicture(image,this.Path);
            return image;            
        }
    }
}