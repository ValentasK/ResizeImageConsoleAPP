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
            while (true)
            {              
                if (resize.getOneImageDetails().Id != 0)
                {
                    Image imagedetails = resize.getOneImageDetails();
                    Console.WriteLine($"Image ID: {imagedetails.Id}, Image size:" + $" {imagedetails.ImageHeight} x {imagedetails.ImageWidth}");
                    resize.changeImageStatus(imagedetails);
                }
              
            }         
          
        }
    }
}
