using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onha.Kiet;

namespace ChoViecNgheKinh
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var domainHost = @"http://trisieu.free.fr/";
            var webber = new Webber(domainHost);  
            var pageDownloadTask = webber.GetStringAsync("BangGiang/Content_BangGiang_MP3/02_Navigation_Frame.htm");
            System.Console.WriteLine(pageDownloadTask.Result);
        }
    }
}
