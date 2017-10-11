using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.Camera;
using Ciclope.Devices.ServerEngine;
using Ciclope.Devices.Camera.Properties;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class SetImageQualityRequest : Request
    {
        private String camera;
        private int quality;

        public SetImageQualityRequest(String camera, int quality)
            : base(typeof(void))
        {
            this.camera = camera;
            this.quality = quality;
        }

        public override Object Attend()
        {
            if (this.camera != null)
            {
                TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
                driver.ImageQuality = this.quality;

                return null;
            }
            else
                throw new Exception("A problem has occurred while trying to set the driver image quality.");
        }

    }
}
