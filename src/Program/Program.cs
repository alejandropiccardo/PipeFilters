using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            //ejercicio1()
            ejercicio2();
        }

        static void ejercicio1()
        {
            //constructores
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");
            IPipe final = new PipeNull();//termina                              3
            IFilter negative1 = new FilterNegative();
            IPipe serial2 = new PipeSerial(negative1,final);//                  2
            IFilter gris = new FilterGreyscale();//1er filtro
            IPipe serial1 = new PipeSerial(gris,serial2);// 1pipe EMPIEZOOO     1
            //accion y guardado
            PictureProvider provider2 = new PictureProvider();
            provider.SavePicture(serial1.Send(picture), @"intento1.jpg");

        }
        static void ejercicio2()
        {
                IFilter neg = new FilterNegative();       
                IFilter gris = new FilterGreyscale();
                IFilter save2 = new FilterSave(@"lukeInt2");
                IFilter save1 = new FilterSave(@"LukeInt1");
            IPipe fin = new PipeNull();
            IPipe serial3 = new PipeSerial(save1,fin);
            IPipe serial2 = new PipeSerial(neg,serial3);
            IPipe serial4 = new PipeSerial(save2,serial2);
            IPipe serial1 = new PipeSerial(gris,serial4);// 1pipe EMPIEZOOO

            //accion
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            serial1.Send(picture);
        }
       
    }
}
