using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CognitiveCoreUCU;
using System.Drawing;

namespace CompAndDel.Pipes
{
    public class PipeConditionalFace : IPipe
    {
        protected IFilter filtro;
        protected IPipe nextPipe;
        
        /// <summary>
        /// La cañería recibe una imagen, le aplica un filtro y la envía a la siguiente cañería
        /// </summary>
        /// <param name="filtro">Filtro que se debe aplicar sobre la imagen</param>
        /// <param name="nextPipe">Siguiente cañería</param>
        public PipeConditionalFace(IPipe haveFace, IPipe noFace,string path)
        {
            this.NoFace=noFace;
            this.HaveFace=haveFace;
            this.Path=path;
        }
        /// <summary>
        /// Devuelve el proximo IPipe
        /// </summary>
        public string Path{get;set;}
        public IPipe NoFace
        {
            get { return this.NoFace; }
            set{;}
        }
         public IPipe HaveFace
        {
            get { return this.HaveFace; }
            set{;}
        }
        
        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        public IPicture Send(IPicture picture)
        {
            CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
            cog.Recognize(this.Path);
            if (cog.FaceFound)
            {
                return this.HaveFace.Send(picture);
            }
            else
            {
                return this.NoFace.Send(picture);
            }
            
        }
    }
}
