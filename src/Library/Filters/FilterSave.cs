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
        private string Name;
        public FilterSave(string path)
        {
            string Name=path;
            
        }


        /// Procesa la imagen pasada por parametro mediante un kernel, y retorna la imagen resultante.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a plicar el filtro.</param>
        /// <returns>La imagen con el filtro aplicado.</returns>
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, this.Name);
            return image;


            
        }
    }
}