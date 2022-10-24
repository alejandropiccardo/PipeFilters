using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    /// <summary>
    /// se encarga de guardar una imagen
    /// </summary>
    public class FilterSave : IFilter
    {
        /// <summary>
        /// guarda la imagen en path
        /// </summary>
        public FilterSave(string path)
        {
            string Path=path;   
        }
        public string Path { get; set; }


        /// Procesa la imagen pasada por parametro mediante un kernel, y retorna la imagen resultante.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a plicar el filtro.</param>
        /// <returns>La imagen con el filtro aplicado.</returns>
        public IPicture Filter(IPicture image)
        {
            string path2=Path;//@"x.jpg";
            PictureProvider providerinternal1 = new PictureProvider();
            providerinternal1.SavePicture(image,path2);
            return image;


            
        }
    }
}