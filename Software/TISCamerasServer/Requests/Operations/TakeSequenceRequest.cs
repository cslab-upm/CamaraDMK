using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Devices.Camera.Server;
using Ciclope.Devices.Camera;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class TakeSequenceRequest : Request
    {
        private String camera;
        private String path = null;
        private String image;
        private int frames;
        private int quality = -1;

        public TakeSequenceRequest(String camera, int frames, String path, String name)
            : base(typeof(void))
        {
            this.camera = camera;
            this.frames = frames;
            this.path = path;
            this.image = name;
        }

        public TakeSequenceRequest(String camera, int frames, String path, String name, int quality)
            : base(typeof(void))
        {
            this.camera = camera;
            this.frames = frames;
            this.path = path;
            this.image = name;
            this.quality = quality;
        }

        public TakeSequenceRequest(String camera, int frames, String name)
            : base(typeof(void))
        {
            if (ServerConfig.ImagesPathSet)
            {
                this.camera = camera;
                this.frames = frames;
                this.path = ServerConfig.ImagesPath;
                this.image = name;
            }
        }

        public TakeSequenceRequest(String camera, int frames, String name, int quality)
            : base(typeof(void))
        {
            if (ServerConfig.ImagesPathSet)
            {
                this.camera = camera;
                this.frames = frames;
                this.path = ServerConfig.ImagesPath;
                this.image = name;
                this.quality = quality;
            }
        }

        public override Object Attend()
        {
            if (this.path != null)
            {
                TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);

                if (this.quality < 0)
                    driver.TakeSequence(frames, path, image);
                else
                    driver.TakeSequence(frames, path, image, quality);

                return null;
            }
            else
                throw new Exception("The path is not defined.");
        }

    }
}
