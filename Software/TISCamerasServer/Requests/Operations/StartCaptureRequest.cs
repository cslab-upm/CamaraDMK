using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Devices.Camera.Server;
using Ciclope.Devices.Camera;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class StartCaptureRequest : Request
    {
        private String camera;
        private String path = null;
        private String video;
        private String codec;

        public StartCaptureRequest(String camera, String path, String name, String codec)
            : base(typeof(void))
        {
            this.camera = camera;
            this.path = path;
            this.video = name;
            this.codec = codec;
        }

        public StartCaptureRequest(String camera, String name, String codec)
            : base(typeof(void))
        {
            if (ServerConfig.VideosPathSet)
            {
                this.camera = camera;
                this.path = ServerConfig.VideosPath;
                this.video = name;
                this.codec = codec;
            }
        }

        public override Object Attend()
        {
            if (this.path != null)
            {
                TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
                driver.StartCapture(this.path, this.video, this.codec);

                return null;
            }
            else
                throw new Exception("The path is not defined.");
        }

    }
}
