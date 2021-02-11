using ResizeImageConsoleAPP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ResizeImageConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            ResizeImage resize = new ResizeImage();
            resize.Initialize(1000);

            Console.ReadKey();
            Console.ReadKey();

        }
    }
}
