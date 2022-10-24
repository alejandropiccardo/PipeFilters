using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;
namespace CompAndDel

{
    class Program
    {
        static void Main(string[] args)
        {
            //ejercicio1();
            //intentodeSave();
            ejercicio3();
        }

        static void ejercicio1()
        {
            //constructores
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            IPipe final = new PipeNull();//termina                              3
            IFilter negative1 = new FilterNegative();
            IPipe serial2 = new PipeSerial(negative1,final);//                  2
            IFilter gris = new FilterGreyscale();//1er filtro
            IPipe serial1 = new PipeSerial(gris,serial2);// 1pipe EMPIEZOOO     1
            //accion y guardado
            PictureProvider provider2 = new PictureProvider();
            provider.SavePicture(serial1.Send(picture), @"intento1.jpg");

        }
        static void ejercicio3();
        {
            IPicture picture = provider.GetPicture(@"luke.jpg");
            IPipe final = new PipeNull();
            IFilter gris = new FilterGreyscale();
            IFilter tw1= new FilterTwitter();
            IPipe serial2 = new PipeSerial(tw1,final);
            IPipe serial1 = new PipeSerial(gris,serial2);
        }
    
       
    }
}
