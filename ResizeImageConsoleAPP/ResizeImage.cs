using Microsoft.EntityFrameworkCore;
using ResizeImageConsoleAPP.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ResizeImageConsoleAPP
{
    class ResizeImage
    {
        private readonly SaveImageToFolderContext _context;
        Timer timer;
        private double timerInterval;
        public ResizeImage()
        {
            _context = new SaveImageToFolderContext();
        }

        public void Initialize(double TimeInterval)
        {
            timerInterval = TimeInterval;
            timer = new Timer(3000);
            timer.Elapsed += (sender, e) =>  Timer_ElapsedAsync();
            timer.Start();
        }

        private void Timer_ElapsedAsync()
        {
            Console.WriteLine($"Timer is running {DateTime.Now}");

            ImageDetails imageDetails = getOneImageDetailsFromDB();
            if (imageDetails.Id != 0)
            {
                timer.Stop();
               resizeImageAccordingly(imageDetails);
            }
        }

        private ImageDetails getOneImageDetailsFromDB()
        {
            ImageDetails imageDetails = _context.Images.FirstOrDefault<ImageDetails>((x) => x.Resized == false);
            if (imageDetails == null)
            {
                return new ImageDetails() { Id = 0 };
            }         
            return imageDetails;
        }

        private void resizeImageAccordingly(ImageDetails imageDetails)
        {
            Image imgPhoto = Image.FromFile($"C:/Photo_Resizer/Original_Images/{imageDetails.ImageId}");
            Bitmap image = ResizeImg(imgPhoto, int.Parse(imageDetails.ImageWidth.ToString()), int.Parse(imageDetails.ImageHeight.ToString()));
            image.Save($"C:/Photo_Resizer/Resized_Images/{imageDetails.ImageId}");

            changeImageStatus(imageDetails);
        }

        public static Bitmap ResizeImg(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }


        private void changeImageStatus(ImageDetails imageDetails)
        {
            imageDetails.Resized = true;

            _context.Entry(imageDetails).State = EntityState.Modified;
            _context.SaveChanges();
         
            Console.WriteLine($"Image saved ID: {imageDetails.Id}");
            timer.Interval = timerInterval;
            timer.Start();
        

        }

    }
}
