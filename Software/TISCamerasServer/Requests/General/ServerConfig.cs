using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ciclope.Devices.Camera.Server
{
    public static class ServerConfig
    {
        private static String imagesPath;
        private static bool imagePathSetup = false;
        private static String videosPath;
        private static bool videosPathSetup = false;
        private static Object sincro = new Object();

        public static String ImagesPath
        {
            get
            {
                return imagesPath;
            }
            set
            {
                lock (sincro)
                {
                    imagePathSetup = true;
                    imagesPath = value;
                }
            }
        }

        public static bool ImagesPathSet
        {
            get
            {
                lock (sincro)
                {
                    return imagePathSetup;
                }
            }
        }


        public static String VideosPath
        {
            get
            {
                return videosPath;
            }
            set
            {
                lock (sincro)
                {
                    videosPathSetup = true;
                    videosPath = value;
                }
            }
        }

        public static bool VideosPathSet
        {
            get
            {
                lock (sincro)
                {
                    return videosPathSetup;
                }
            }
        }

    }
}
