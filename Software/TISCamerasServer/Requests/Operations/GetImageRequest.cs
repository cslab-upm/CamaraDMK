using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Utils;
using System.IO;
using System.Collections;
using Ciclope.Devices.DriverEngine;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetImageRequest : Request
    {
        private String file;
        private String path = null;
        private int width;
        private int height;

        public GetImageRequest(String image)
            : base(typeof(MemoryStream))
        {
            if (ServerConfig.ImagesPathSet)
            {
                this.path = ServerConfig.ImagesPath;
                this.file = image;
            }
        }

        public GetImageRequest(String image, int width, int height)
            : base(typeof(MemoryStream))
        {
            if (ServerConfig.ImagesPathSet)
            {
                this.path = ServerConfig.ImagesPath;
                this.file = image;
                this.width = width;
                this.height = height;
            }
        }

        public override Object Attend()
        {
            if (path != null)
            {
                String[] filterExtensions = new string[] { "*.bmp", "*.jpg", "*.tif" };
                List<String> allFiles = new List<String>();

                foreach (String filter in filterExtensions)
                {
                    String[] paths = Directory.GetFiles(this.path + "/", filter);
                    allFiles.AddRange(paths);
                }

                String existingFile = allFiles.ToArray().FirstOrDefault<String>(e=> e.Contains(this.file));

                if (existingFile != null)
                {
                    System.Drawing.Image image;
                    MemoryStream stream = new MemoryStream();
                        
                    lock (DriverOperation.WriteSync)
                    {
                        image = Image.FromFile(existingFile);

                        Image resizedImage = ResizeImage(image, new Size(this.width, this.height));
                        resizedImage.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        stream.Position = 0;
                    }
                    
                    return stream;    
                }
                else
                    throw new Exception("The image does not exist.");
            }
            else
                throw new Exception("The path is not defined.");
        }

        private Image ResizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.Default;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

    }
}
