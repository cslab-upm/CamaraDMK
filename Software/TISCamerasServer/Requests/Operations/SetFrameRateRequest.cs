using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class SetFrameRateRequest : Request
    {
        private String camera;
        private Double frameRate;

        public SetFrameRateRequest(String camera, Double frameRate)
            : base(typeof(void))
        {
            this.camera = camera;
            this.frameRate = frameRate;
        }

        public override Object Attend()
        {
            TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
            driver.FrameRate = (float)this.frameRate;

            return null;
        }

    }
}
