using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CognitiveCoreUCU;

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
        public PipeConditionalFace(IPipe haveFace, IPipe noFace)
        {
            this.NoFace=noFace;
            this.HaveFace=haveFace;
        }
        /// <summary>
        /// Devuelve el proximo IPipe
        /// </summary>
        public IPipe NoFace
        {
            get { return this.NoFace; }
        }
         public IPipe HaveFace
        {
            get { return this.HaveFace; }
        }
        
        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        public IPicture Send(IPicture picture)
        {
            picture = this.filtro.Filter(picture);
            return this.nextPipe.Send(picture);
        }
    }
}
