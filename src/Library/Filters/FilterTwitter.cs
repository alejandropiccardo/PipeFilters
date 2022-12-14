using System;
using System.Drawing;
using CompAndDel;
using TwitterUCU;
namespace CompAndDel.Filters
{
    public class FilterTwitter : IFilter
    {
        /// <summary>
        /// guarda la imagen en path
        /// </summary>
        public FilterTwitter(string msg,string path)
        {
            this.Path=path;
            this.Msg=msg;   
        }
        public string Msg { get; set; }
        public string Path {get; set; }
        public IPicture Filter(IPicture image)
        {
            //string path2=Path;//@"x.jpg";
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter(this.Msg, this.Path));
            return image;            
        }
    }
}