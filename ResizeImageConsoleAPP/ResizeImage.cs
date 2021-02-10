using Microsoft.EntityFrameworkCore;
using ResizeImageConsoleAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResizeImageConsoleAPP
{
    class ResizeImage
    {
        private readonly SaveImageToFolderContext _context;
        public ResizeImage()
        {
            _context = new SaveImageToFolderContext();
        }

        public Image getOneImageDetails()
        {
            if (_context.Images.FirstOrDefault((x) => x.Resized == false) == null)
            {
                return new Image() { Id = 0 };
            }

            Image imageDetails = _context.Images.FirstOrDefault((x) => x.Resized == false);
            return imageDetails;
        }

        public void resizeImage()
        {
        }

        public void changeImageStatus(Image image)
        {
            image.Resized = true;

            _context.Entry(image).State = EntityState.Modified;
            _context.SaveChanges();
               
        }
    }
}
