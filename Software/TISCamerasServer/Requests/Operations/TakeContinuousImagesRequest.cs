using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class TakeContinuousImagesRequest : Request
    {
        private String camera;
        private String path = null;
        private String image;
        private int latency;
        private int quality = -1;

        public TakeContinuousImagesRequest(String camera, String path, String name, int latency)
            : base(typeof(void))
        {
            this.camera = camera;
            this.path = path;
            this.image = name;
            this.latency = latency;
        }

        public TakeContinuousImagesRequest(String camera, String path, String name, int latency, int quality)
            : base(typeof(void))
        {
            this.camera = camera;
            this.path = path;
            this.image = name;
            this.latency = latency;
            this.quality = quality;
        }

        public TakeContinuousImagesRequest(String camera, String name, int latency)
            : base(typeof(void))
        {
            if (ServerConfig.ImagesPathSet)
            {
                this.camera = camera;
                this.path = ServerConfig.ImagesPath;
                this.image = name;
                this.latency = latency;
            }
        }

        public TakeContinuousImagesRequest(String camera, String name, int latency, int quality)
            : base(typeof(void))
        {
            if (ServerConfig.ImagesPathSet)
            {
                this.camera = camera;
                this.path = ServerConfig.ImagesPath;
                this.image = name;
                this.latency = latency;
                this.quality = quality;
            }
        }

        public override Object Attend()
        {
            if (this.path != null)
            {
                TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);

                if (quality < 0)
                    driver.TakeContinuousImages(path, image, latency);
                else
                    driver.TakeContinuousImages(path, image, latency, quality);

                return null;
            }
            else
                throw new Exception("The path is not defined.");
        }

    }
}
