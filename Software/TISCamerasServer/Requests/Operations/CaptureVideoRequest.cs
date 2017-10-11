using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class CaptureVideoRequest : Request
    {
        private String camera;
        private String path = null;
        private String video;
        private String codec;
        private int time;

        public CaptureVideoRequest(String camera, String path, String video, String codec, int time)
            : base(typeof(void))
        {
            this.camera = camera;
            this.path = path;
            this.video = video;
            this.codec = codec;
            this.time = time;
        }

        public CaptureVideoRequest(String camera, String video, String codec, int time)
            : base(typeof(void))
        {
            if (ServerConfig.VideosPathSet)
            {
                this.camera = camera;
                this.path = ServerConfig.VideosPath;
                this.video = video;
                this.codec = codec;
                this.time = time;
            }
        }

        public override Object Attend()
        {
            if (this.path != null)
            {
                TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
                driver.CaptureVideo(this.path, this.video, this.codec, this.time);

                return null;
            }
            else
                throw new Exception("The path is not defined.");
        }

    }
}
