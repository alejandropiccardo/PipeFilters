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
            IPipe serial2 = new PipeSerial(negative1, final);//                  2
            IFilter gris = new FilterGreyscale();//1er filtro
            IPipe serial1 = new PipeSerial(gris, serial2);// 1pipe EMPIEZOOO     1
            //accion y guardado
            PictureProvider provider2 = new PictureProvider();
            provider.SavePicture(serial1.Send(picture), @"intento1.jpg");

        }
        static void ejercicio3()
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            IPipe final = new PipeNull();
            IFilter neg = new FilterNegative();
            IFilter tw1= new FilterTwitter("Luke esta Loco","SubirATw.jpg");
            IFilter s1 = new FilterSave("SubirATw.jpg");
            IPipe serial3 = new PipeSerial(tw1,final);
            IPipe serial2 = new PipeSerial(s1,serial3);
            IPipe serial1 = new PipeSerial(neg,serial2);

            PictureProvider provider2 = new PictureProvider();
            provider.SavePicture(serial1.Send(picture), @"intento1.jpg");
        }


    }
}
