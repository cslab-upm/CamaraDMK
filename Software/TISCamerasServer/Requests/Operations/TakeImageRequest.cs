using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Devices.Camera.Server;
using Ciclope.Devices.Camera;
using Ciclope.Devices.Camera.Properties;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class TakeImageRequest : Request
    {
        private String camera;
        private String path = null;
        private String image;
        private Double exposure = Double.NaN;
        private int quality = -1;

        public TakeImageRequest(String camera, String path, String name)
            : base(typeof(void))
        {
            this.camera = camera;
            this.path = path;
            this.image = name;
        }

        public TakeImageRequest(String camera, String path, String name, int quality)
            : base(typeof(void))
        {
            this.camera = camera;
            this.path = path;
            this.image = name;
            this.quality = quality;
        }

        public TakeImageRequest(String camera, String path, String name, double exposure)
            : base(typeof(void))
        {
            this.camera = camera;
            this.path = path;
            this.image = name;
            this.exposure = exposure;
        }

        public TakeImageRequest(String camera, String path, String name, double exposure, int quality)
            : base(typeof(void))
        {
            this.camera = camera;
            this.path = path;
            this.image = name;
            this.exposure = exposure;
            this.quality = quality;
        }

        public TakeImageRequest(String camera, String name)
            : base(typeof(void))
        {
            if (ServerConfig.ImagesPathSet)
            {
                this.camera = camera;
                this.path = ServerConfig.ImagesPath;
                this.image = name;
            }
        }

        public TakeImageRequest(String camera, String name, int quality)
            : base(typeof(void))
        {
            if (ServerConfig.ImagesPathSet)
            {
                this.camera = camera;
                this.path = ServerConfig.ImagesPath;
                this.image = name;
                this.quality = quality;
            }
        }

        public TakeImageRequest(String camera, String name, Double exposure)
            : base(typeof(void))
        {
            if (ServerConfig.ImagesPathSet)
            {
                this.camera = camera;
                this.path = ServerConfig.ImagesPath;
                this.image = name;
                this.exposure = exposure;
            }
        }

        public TakeImageRequest(String camera, String name, Double exposure, int quality)
            : base(typeof(void))
        {
            if (ServerConfig.ImagesPathSet)
            {
                this.camera = camera;
                this.path = ServerConfig.ImagesPath;
                this.image = name;
                this.exposure = exposure;
                this.quality = quality;
            }
        }

        public override Object Attend()
        {
            if (path != null)
            {
                TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);

                if (!Double.IsNaN(this.exposure))
                {
                    double expValue = this.exposure;
                    driver.GetProperty(PropertyType.EXPOSURE).Auto = false;
                    driver.GetProperty(PropertyType.EXPOSURE).Value = expValue;
                }

                if (quality < 0)
                    driver.TakeImage(path, image);
                else
                    driver.TakeImage(path, image, quality);

                return null;
            }
            else
                throw new Exception("The path is not defined.");
        }

    }
}
