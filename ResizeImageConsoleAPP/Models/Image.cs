using System;
using System.Collections.Generic;

#nullable disable

namespace ResizeImageConsoleAPP.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string ImageId { get; set; }
        public string UserName { get; set; }
        public bool Resized { get; set; }
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
    }
}
